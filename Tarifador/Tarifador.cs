
public class Tarifador
{
    private List<Usuario> usuarios = new List<Usuario>();
    public void addUsuario(Usuario usuario)
    {

        usuarios.Add(usuario);
    }

    public List<Usuario> getListaUsuarios()
    {
        return usuarios;
    }

    public void addListaUsuarios(List<Usuario> listaUsuarios)
    {
        this.usuarios = listaUsuarios;
    }

    public void tarifar(List<IDescuento> descuentos,IImpuesto impuesto)
    {        
        this.usuarios.ForEach( usuario =>  usuario.calcularMontoTotalRegistros(descuentos,impuesto));
    }

    public void aniadirRegistroAUsuario(int ciUsuario, Registro registro){
        Usuario usuario = usuarios.Find(usuarios => usuarios.ci == ciUsuario);
        if (usuario != null)
        {
            usuario.agregarNuevoRegistro(registro);
        }
    }

    public void mostrarMontoPorUsuario(){
        this.usuarios.ForEach( usuario => usuario.mostrarMontoPorPagar());
    }
}