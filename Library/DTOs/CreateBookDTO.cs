
namespace Library.DTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int ReleaseYear { get; set; }

        public List<CreateAuthorDTO> Authors { get; set; } = new List<CreateAuthorDTO>();
    }
}
