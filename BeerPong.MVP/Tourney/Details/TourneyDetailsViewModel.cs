namespace BeerPong.MVP.Tourney.Details
{
    public class TourneyDetailsViewModel
    {

        public TourneyDetailsViewModel()
        {

        }

        public TourneyDetailsViewModel(int id, string name, bool hasJoined)
        {
            this.Id = id;
            this.Name = name;
            this.HasJoined = hasJoined;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool HasJoined { get; set; }
    }
}
