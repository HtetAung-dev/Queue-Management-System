namespace qms.Models;

public class Token
{
    public int Qid { get; set;}
    public String? Ticket { get; set; }
    public String? Customer { get; set;}
    public String? PlateNo { get; set; }
    public String? ContactNo { get; set; }
    public int QueueIndex { get; set; }
    public DateTime CreatedAt { get; set; }
}