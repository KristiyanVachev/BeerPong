namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsViewModel
    {

        public TourneyDetailsViewModel()
        {

        }

        public TourneyDetailsViewModel(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
