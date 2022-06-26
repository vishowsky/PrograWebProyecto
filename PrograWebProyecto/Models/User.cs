namespace PrograWebProyecto.Models
{
    public class User
    {

        public int Id { get; set; }
        public string? Rut { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public int? Password { get; set; }
        public int? Telefono { get; set; }
 
        
        //FK
        public int IdCargo { get; set; }
        public Cargo? Cargo { get; set; }
        public int IdTurno { get; set; }
        public Turno? Turno { get; set; }
        public int IdGenero { get; set; }
        public Genero? Genero { get; set; }
        public int IdCivil { get; set; }
        public Civil? Civil { get; set; }

    }
}
