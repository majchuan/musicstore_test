using Microsoft.EntityFrameworkCore;

public class ArtistServiceTest : IDisposable
{
    private readonly ApplicationContext _ac ;

    public ArtistServiceTest()
    {
        var options = new DbContextOptionsBuilder<ApplicationContext>().
        UseSqlServer("Server=DESKTOP-MARK\\SQLEXPRESS2017;Database=musicstore;Trusted_Connection=True;Encrypt=False;").Options;

        _ac = new ApplicationContext(options);
        _ac.Database.EnsureCreated();
    } 

    [Fact]
    public void GetAllAristsCountsTest()
    {
        // Given
        var repo = new UnitOfWork(_ac);
        var result = repo.ArtistRepository.GetAll();
        Assert.Equal(3, result.Count() );
    }

    [Fact]
    public void GetArtistByIDTest()
    {
        // Given
        var repo = new UnitOfWork(_ac);
        var result = repo.ArtistRepository.GetById(4);
        Assert.Equal("Muse", result.Name );
    }

    public void Dispose()
    {
        _ac.Dispose();
    }
}