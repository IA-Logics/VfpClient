using System;
using MapDataReader;

namespace VfpClient.Benchmarks;

[GenerateDataReaderMapper]
public partial class PreservationWorkOrder
{
    public bool Active { get; set; }
    public string? Workorder { get; set; }
    public DateTime? Workorderd { get; set; }
    public string? Workorderu { get; set; }
    public string? PresCd { get; set; }
    public string? VarCd { get; set; }
    public string? Desc { get; set; }
    public string? Statuscd { get; set; }
    public string? Status { get; set; }
    public string? Resultcd { get; set; }
    public string? Result { get; set; }
    public decimal? Charges { get; set; }
    public string? Distrib { get; set; }
    public string? Makecd { get; set; }
    public string? Make { get; set; }
    public string? Modelcd { get; set; }
    public string? Model { get; set; }
    public string? Rentalcd { get; set; }
    public string? Baseccode { get; set; }
    public string? Basecolor { get; set; }
    public string? Colorcd { get; set; }
    public string? Color { get; set; }
    public string? Colorintcd { get; set; }
    public string? Colorint { get; set; }
    public string? Vin { get; set; }
    public string? Engine { get; set; }
    public string? Regno { get; set; }
    public string? Keyno { get; set; }
    public string? Refno { get; set; }
    public DateTime? Factdate { get; set; }
    public int? Mandate { get; set; }
    public int? Modelyear { get; set; }
    public string? Vehtype { get; set; }
    public string? Shipno { get; set; }
    public string? Shipref { get; set; }
    public DateTime? Storedd { get; set; }
    public string? Mvdepotcd { get; set; }
    public string? Mvdepot { get; set; }
    public DateTime? Mvdepotd { get; set; }
    public bool Onhold { get; set; }
    public DateTime? Onholdd { get; set; }
    public string? Onholdu { get; set; }
    public DateTime? Scannedin { get; set; }
    public DateTime? Scannedout { get; set; }
    public bool Approved { get; set; }
    public DateTime? Approvedd { get; set; }
    public string? Approvedu { get; set; }
    public bool Canceled { get; set; }
    public DateTime? Canceledd { get; set; }
    public string? Canceledu { get; set; }
    public bool Completed { get; set; }
    public DateTime? Completedd { get; set; }
    public string? Completedu { get; set; }
    public bool Closed { get; set; }
    public DateTime? Closedd { get; set; }
    public string? Closedu { get; set; }
    public string? Notes { get; set; }
    public string? Group { get; set; }
    public string? Company { get; set; }
    public string? Branch { get; set; }
    public string? Userid { get; set; }
    public DateTime? Cdate { get; set; }
    public string PresNo { get; set; } = default!;
    public DateTime? Presd { get; set; }
    public string? Presu { get; set; }
    public string? Invno { get; set; }
    public DateTime? Invd { get; set; }
    public string? Invu { get; set; }
    public decimal? Invv { get; set; }
    public string? Vehclass { get; set; }
    public string? Prestype { get; set; }
    public DateTime? Bayd { get; set; }
    public string? Baycd { get; set; }
    public string? Bay { get; set; }
    public string? Bay1 { get; set; }
    public string? Bay2 { get; set; }
    public string? Bay3 { get; set; }
    public string? Presprovcd { get; set; }
    public string? Presprovno { get; set; }
    public string? Msgid { get; set; }
    public string? Msgref { get; set; }
    public string? Msgtype { get; set; }
    public string? Msgcode { get; set; }
    public string? Msgcode2 { get; set; }
    public string? Msgdesc { get; set; }
    public string? Msgprovcd { get; set; }
    public int? Msgitemno { get; set; }
    public int? Msgprty { get; set; }
    public DateTime? Msgdue { get; set; }
    public DateTime? Msgsync { get; set; }
    public string? Msgsyncu { get; set; }

    public PreservationWorkOrder()
    {
    }

    public PreservationWorkOrder(
        bool active,
        string? workorder,
        DateTime? workorderd,
        string? workorderu,
        string? presCd,
        string? varCd,
        string? desc,
        string? statuscd,
        string? status,
        string? resultcd,
        string? result,
        decimal? charges,
        string? distrib,
        string? makecd,
        string? make,
        string? modelcd,
        string? model,
        string? rentalcd,
        string? baseccode,
        string? basecolor,
        string? colorcd,
        string? color,
        string? colorintcd,
        string? colorint,
        string? vin,
        string? engine,
        string? regno,
        string? keyno,
        string? refno,
        DateTime? factdate,
        int? mandate,
        int? modelyear,
        string? vehtype,
        string? shipno,
        string? shipref,
        DateTime? storedd,
        string? mvdepotcd,
        string? mvdepot,
        DateTime? mvdepotd,
        bool onhold,
        DateTime? onholdd,
        string? onholdu,
        DateTime? scannedin,
        DateTime? scannedout,
        bool approved,
        DateTime? approvedd,
        string? approvedu,
        bool canceled,
        DateTime? canceledd,
        string? canceledu,
        bool completed,
        DateTime? completedd,
        string? completedu,
        bool closed,
        DateTime? closedd,
        string? closedu,
        string? notes,
        string? group,
        string? company,
        string? branch,
        string? userid,
        DateTime? cdate,
        string presNo,
        DateTime? presd,
        string? presu,
        string? invno,
        DateTime? invd,
        string? invu,
        decimal? invv,
        string? vehclass,
        string? prestype,
        DateTime? bayd,
        string? baycd,
        string? bay,
        string? bay1,
        string? bay2,
        string? bay3,
        string? presprovcd,
        string? presprovno,
        string? msgid,
        string? msgref,
        string? msgtype,
        string? msgcode,
        string? msgcode2,
        string? msgdesc,
        string? msgprovcd,
        int? msgitemno,
        int? msgprty,
        DateTime? msgdue,
        DateTime? msgsync,
        string? msgsyncu)
    {
        Active = active;
        Workorder = workorder;
        Workorderd = workorderd;
        Workorderu = workorderu;
        PresCd = presCd;
        VarCd = varCd;
        Desc = desc;
        Statuscd = statuscd;
        Status = status;
        Resultcd = resultcd;
        Result = result;
        Charges = charges;
        Distrib = distrib;
        Makecd = makecd;
        Make = make;
        Modelcd = modelcd;
        Model = model;
        Rentalcd = rentalcd;
        Baseccode = baseccode;
        Basecolor = basecolor;
        Colorcd = colorcd;
        Color = color;
        Colorintcd = colorintcd;
        Colorint = colorint;
        Vin = vin;
        Engine = engine;
        Regno = regno;
        Keyno = keyno;
        Refno = refno;
        Factdate = factdate;
        Mandate = mandate;
        Modelyear = modelyear;
        Vehtype = vehtype;
        Shipno = shipno;
        Shipref = shipref;
        Storedd = storedd;
        Mvdepotcd = mvdepotcd;
        Mvdepot = mvdepot;
        Mvdepotd = mvdepotd;
        Onhold = onhold;
        Onholdd = onholdd;
        Onholdu = onholdu;
        Scannedin = scannedin;
        Scannedout = scannedout;
        Approved = approved;
        Approvedd = approvedd;
        Approvedu = approvedu;
        Canceled = canceled;
        Canceledd = canceledd;
        Canceledu = canceledu;
        Completed = completed;
        Completedd = completedd;
        Completedu = completedu;
        Closed = closed;
        Closedd = closedd;
        Closedu = closedu;
        Notes = notes;
        Group = group;
        Company = company;
        Branch = branch;
        Userid = userid;
        Cdate = cdate;
        PresNo = presNo;
        Presd = presd;
        Presu = presu;
        Invno = invno;
        Invd = invd;
        Invu = invu;
        Invv = invv;
        Vehclass = vehclass;
        Prestype = prestype;
        Bayd = bayd;
        Baycd = baycd;
        Bay = bay;
        Bay1 = bay1;
        Bay2 = bay2;
        Bay3 = bay3;
        Presprovcd = presprovcd;
        Presprovno = presprovno;
        Msgid = msgid;
        Msgref = msgref;
        Msgtype = msgtype;
        Msgcode = msgcode;
        Msgcode2 = msgcode2;
        Msgdesc = msgdesc;
        Msgprovcd = msgprovcd;
        Msgitemno = msgitemno;
        Msgprty = msgprty;
        Msgdue = msgdue;
        Msgsync = msgsync;
        Msgsyncu = msgsyncu;
    }
}
