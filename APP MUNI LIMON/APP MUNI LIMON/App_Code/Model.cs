﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Actividades
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Actividades()
    {
        this.Inscripciones = new HashSet<Inscripciones>();
    }

    public string nombre { get; set; }
    public string fecha { get; set; }
    public string tipoActividad { get; set; }
    public string direccion { get; set; }
    public string descripcion { get; set; }
    public int cupos { get; set; }
    public string imagenes { get; set; }

    public virtual tipoActividades tipoActividades { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Inscripciones> Inscripciones { get; set; }
}

public partial class Inscripciones
{
    public string tipoActividad { get; set; }
    public string actividad { get; set; }
    public string correoInscrito { get; set; }
    public int idInscripcion { get; set; }

    public virtual Actividades Actividades { get; set; }
    public virtual Usuario Usuario { get; set; }
    public virtual tipoActividades tipoActividades { get; set; }
}

public partial class Noticias
{
    public string titulo { get; set; }
    public string descripcion { get; set; }
    public string multimedia { get; set; }
}

public partial class Sugerencias
{
    public int numeroSugerencia { get; set; }
    public Nullable<int> isAnonima { get; set; }
    public string correo { get; set; }
    public string tipoTramite { get; set; }
    public Nullable<int> valoracion { get; set; }
    public string descripcion { get; set; }
}

public partial class tipoActividades
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public tipoActividades()
    {
        this.Actividades = new HashSet<Actividades>();
        this.Inscripciones = new HashSet<Inscripciones>();
    }

    public string nombre { get; set; }
    public string descripcion { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Actividades> Actividades { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Inscripciones> Inscripciones { get; set; }
}

public partial class Usuario
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Usuario()
    {
        this.Inscripciones = new HashSet<Inscripciones>();
    }

    public string nombre { get; set; }
    public string correo { get; set; }
    public string contrasenna { get; set; }
    public int telefono { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Inscripciones> Inscripciones { get; set; }
}