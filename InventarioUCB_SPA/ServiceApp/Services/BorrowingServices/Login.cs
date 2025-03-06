public class LoginData{
    public int? UserId { get; set; }
    public LoginData(){
        UserId = null;
    }
    public void AgregarId(int? id){
        UserId = id;
    }
    public void CerrarSesion(){
        UserId = null;
    }
}