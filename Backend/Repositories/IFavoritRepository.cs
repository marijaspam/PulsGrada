using PulsGrada.Models;

public interface IFavoritRepository
{
    List<Favorit> DohvatiFavoriteKorisnika(int idKorisnika);
    Favorit? DohvatiFavorit(int idKorisnika, int idLokala);
    bool DodajFavorit(Favorit favorit);
    bool ObrisiFavorit(Favorit favorit);
}