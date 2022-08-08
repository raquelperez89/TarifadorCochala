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

    public void addListaRegistros(List<Registro> listaRegistros)
    {
        this.registros = listaRegistros;
    }
    public void addListaUsuarios(List<Usuario> listaUsuarios)
    {
        this.usuarios = listaUsuarios;
    }

    public void tarifar()
    {        
        this.usuarios.ForEach( usuario =>  this.registros.ForEach(registro =>
        {
            if(usuario.ci == registro.usuarioCi) 
            {
                registro.calcularMontoRegistro(usuario);
            }
        }));
    }

    public void mostrarMontoPorUsuario(){
        this.usuarios.ForEach( usuario => usuario.mostrarMontoPorPagar());
    }
}