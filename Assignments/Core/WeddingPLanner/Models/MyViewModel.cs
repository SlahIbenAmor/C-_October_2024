using System.ComponentModel.DataAnnotations;

namespace WeddingPLanner.Models;

public class MyViewModel
{
    public User LoggedInUser { get; set; }
    public Wedding NewWedding { get; set; }
    public List<Wedding> AllWeddings { get; set; }
    public List<Wedding> WeddingsRSVPed { get; set; }
}