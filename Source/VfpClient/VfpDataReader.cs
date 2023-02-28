using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Text;

namespace VfpClient;

public partial class VfpDataReader : DbDataReader
{
    private static readonly DateTime NullFoxDate = new(1899, 12, 30, 00, 00, 00);

    private static readonly Encoding DefaultEncoding = Encoding.Default;
    private static readonly char[] TrimChars = { ' ', '\t', '\r', '\n' };

    private Dictionary<string, VfpType> _columnVfpTypes;
    private readonly DbDataReader _dbDataReader;

    public override int Depth => Execute(() => _dbDataReader.Depth);

    public override int FieldCount => Execute(() => _dbDataReader.FieldCount);

    public override bool HasRows => Execute(() => _dbDataReader.HasRows);

    public override bool IsClosed => Execute(() => _dbDataReader.IsClosed);

    public override int RecordsAffected => Execute(() => _dbDataReader.RecordsAffected);

    public override object this[string name] => Execute(() => GetValue(GetOrdinal(name)));

    public override object this[int ordinal] => Execute(() => GetValue(ordinal));

    public override int VisibleFieldCount => Execute(() => _dbDataReader.VisibleFieldCount);

    public VfpDataReader(DbDataReader dbDataReader)
    {
        _ = ArgumentUtility.CheckNotNull("dbDataReader", dbDataReader);

        _dbDataReader = dbDataReader;
    }

    public override void Close()
    {
        Execute(() => _dbDataReader.Close());
    }

    public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length)
    {
        return Execute(() => _dbDataReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length));
    }

    public override char GetChar(int ordinal)
    {
        return Execute(() => _dbDataReader.GetChar(ordinal));
    }

    public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length)
    {
        return Execute(() => _dbDataReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length));
    }

    public override string GetDataTypeName(int ordinal)
    {
        return Execute(() => _dbDataReader.GetDataTypeName(ordinal).ToVfpTypeName());
    }

    public override DateTime GetDateTime(int ordinal)
    {
        return Execute(() => _dbDataReader.GetDateTime(ordinal));
    }

    public override IEnumerator GetEnumerator()
    {
        return Execute(() => _dbDataReader.GetEnumerator());
    }

    public override Type GetFieldType(int ordinal)
    {
        return Execute(() => _dbDataReader.GetFieldType(ordinal));
    }

    public override Guid GetGuid(int ordinal)
    {
        return Execute(() => new Guid(GetString(ordinal)));
    }

    public override short GetInt16(int ordinal)
    {
        return Execute(() => _dbDataReader.GetInt16(ordinal));
    }

    public override int GetInt32(int ordinal)
    {
        return Execute(() => _dbDataReader.GetInt32(ordinal));
    }

    public override long GetInt64(int ordinal)
    {
        return Execute(() => _dbDataReader.GetInt64(ordinal));
    }

    public override decimal GetDecimal(int ordinal)
    {
        return Execute(() => _dbDataReader.GetDecimal(ordinal));
    }

    public override double GetDouble(int ordinal)
    {
        return Execute(() => _dbDataReader.GetDouble(ordinal));
    }

    public override bool GetBoolean(int ordinal)
    {
        return Execute(() => _dbDataReader.GetBoolean(ordinal));
    }

    public override byte GetByte(int ordinal)
    {
        return Execute(() => _dbDataReader.GetByte(ordinal));
    }

    public override float GetFloat(int ordinal)
    {
        return Execute(() => _dbDataReader.GetFloat(ordinal));
    }

    public override string GetName(int ordinal)
    {
        return Execute(() => _dbDataReader.GetName(ordinal).ToProperIfAllLowerCase());
    }

    public override int GetOrdinal(string name)
    {
        return Execute(() => _dbDataReader.GetOrdinal(name));
    }

    public override DataTable GetSchemaTable()
    {
        return Execute(() =>
        {
            var schema = _dbDataReader.GetSchemaTable();

            if (!schema.Columns.Contains("VfpType"))
            {
                new SchemaFixer(this).Fix(schema);
            }

            return schema;
        });
    }

    public override string GetString(int ordinal)
    {
        return Execute(() =>
        {
            var value = _dbDataReader[ordinal];
            if (value == null)
            {
                return null;
            }
            if (value is string stringValue)
            {
                return stringValue.TrimEnd(TrimChars);
            }
            if (value is byte[] byteArrayValue)
            {
                stringValue = DefaultEncoding.GetString(byteArrayValue);
                int length = stringValue.Length;
                int end = length - 1;
                while (end >= 0 && Array.IndexOf(TrimChars, stringValue[end]) != -1)
                {
                    end--;
                }
                return end == length - 1 ? stringValue : stringValue[..(end + 1)];
            }
            return value.ToString().TrimEnd(TrimChars);
        });
    }

    public override object GetValue(int ordinal)
    {
        return Execute(() =>
        {
            var value = _dbDataReader.GetValue(ordinal);

            if (value is null or DBNull)
            {
                return null;
            }

            if (value is string || (value is byte[] byteArrayValue && IsStringType(ordinal)))
            {
                return GetString(ordinal);
            }

            return value;
        });
    }

    public override int GetValues(object[] values)
    {
        ArgumentUtility.CheckNotNull("values", values);

        return Execute(() =>
        {
            int total = Math.Min(values.Length, VisibleFieldCount);

            for (int index = 0; index < total; index++)
            {
                object value = GetValue(index);
                if (value is null or DBNull)
                {
                    values[index] = value;
                }
                else
                {
                    values[index] = value.GetType().IsValueType ? value : value.ToString();
                }
            }
            return total;
        });
    }

    private static readonly HashSet<string> StringColumnNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    private bool IsStringType(int ordinal)
    {
        string columnName = GetName(ordinal);

        if (StringColumnNames.Contains(columnName))
        {
            return true;
        }
        var vfpTypes = GetColumnVfpTypes();

        if (vfpTypes.TryGetValue(columnName, out var vfpType) && vfpType.IsStringType())
        {
            _ = StringColumnNames.Add(columnName);
            return true;
        }
        return false;
    }

    private Dictionary<string, VfpType> GetColumnVfpTypes()
    {
        if (_columnVfpTypes != null)
        {
            return _columnVfpTypes;
        }

        var schemaTable = GetSchemaTable();
        var columnVfpTypes = new Dictionary<string, VfpType>(schemaTable.Rows.Count, StringComparer.OrdinalIgnoreCase);

        foreach (DataRow row in schemaTable.Rows)
        {
            string columnName = row.Field<string>("ColumnName");
            columnVfpTypes[columnName] = (VfpType)row.Field<int>("VfpType");
        }

        _columnVfpTypes = columnVfpTypes;

        return columnVfpTypes;
    }

    public override bool IsDBNull(int ordinal)
    {
        return Execute(() =>
        {
            bool isDBNull = _dbDataReader.IsDBNull(ordinal);
            object objvalue = _dbDataReader.GetValue(ordinal);

            if (objvalue is DateTime dateTime && (dateTime == NullFoxDate))
            {
                isDBNull = true;
            }

            return isDBNull;
        });
    }

    public override bool NextResult()
    {
        return Execute(() => _dbDataReader.NextResult());
    }

    public override bool Read()
    {
        return Execute(() => _dbDataReader.Read());
    }

    protected static void Execute(Action action)
    {
        _ = Execute(() =>
        {
            action();

            return false;
        });
    }

    protected static T Execute<T>(Func<T> func)
    {
        try
        {
            return func();
        }
        catch (OleDbException exception)
        {
            throw new VfpException(exception.Message, exception);
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing && _dbDataReader != null)
        {
            _dbDataReader.Dispose();
        }

        base.Dispose(disposing);
    }
}
