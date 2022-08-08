class Tarifador
{
    private List<Usuario> usuarios;
    private List<Registro> registros;

    public void addRegistro(Registro registro)
    {
        registros.Add(registro);
    }

    public void addUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }
}