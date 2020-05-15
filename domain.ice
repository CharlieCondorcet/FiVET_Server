/*
 * Copyright (c) 2020 Charlie Condorcet Engineer Student.
 *
 * This program is free software: you can redistribute it and/or modify it under the terms of the GNU
 * General Public License as published by the Free Software Foundation, either version 3 of the License, or (at
 * your option) any later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without
 * even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
 * General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License along with this program. If not, see
 * <https://www.gnu.org/licenses/>.
 */

// https://doc.zeroc.com/ice/3.7/language-mappings/java-mapping/client-side-slice-to-java-mapping/customizing-the-java-mapping
["java:package:cl.ucn.disc.pdis.fivet.zeroice", "cs:namespace:Fivet.ZeroIce"]
module model {

    /**
     * Clase Persona
     */
    class Persona {

        /**
         * Pk
         */
        int id;

        /**
         * Rut: 113335557
         */
        string rut;

        /**
         * Nombre
         */
        string nombre;

        /**
         * Direccion
         */
        string direccion;

        /**
         * Telefono Fijo: +55 55 550000
         */
        long telefonoFijo;

       /**
         * Telefono Fijo: +55 55 550000
         */
        long telefonoMovil;

        /**
         * Email
         */
        string email;
    }

    /**
     * Enumeracion para atributo Sexo
     */
     enum Sexo {
         MACHO,
         HEMBRA
     }

     /**
      * TIpo de Paciente
      */
     enum TipoPaciente {
         INTERNO,
         EXTERNO
     }

    /**
     * Clase Ficha
     */
     class Ficha{

        /**
         * PK
         */
         int id;

         /**
          * Numero: 1133
          */
         int numero;

         /**
          * Nombre: Misifus
          */
         string nombre;

         /**
          * Especie: Gatuno
          */
         string especie;

         /**
          * Fecha nacimiento.
          */
         string fecha;

         /**
          * Raza de la mascota.
          */
         string raza;

         /**
          * Sexo paciente; Macho/Hembra
          */
         Sexo sexo;

         /**
          * Tipo pacinte; Interno/Externo
          */
         TipoPaciente tipoPaciente;
     }

     /**
      * Clase Control para las mascotas
      */
      class ControlMascota{

          /**
           * Fecha de emision
           */
           string fecha;

          /**
           * Fecha de proximo control
           */
           string proximoControl;

          /**
           * Temperatura mascota
           */
           double temperatura;

          /**
           * Peso mascota
           */
           double peso;

          /**
           * Altura mascota
           */
           double altura;

          /**
           * Diagnostico para la mascota
           */
           string diagnostico;

          /**
           * Nombre veterinario
           */
           string veterinario;
      }


     /**
      * Clase Examen de Control
      */
      class Examen{

          /**
           * Tipo: Radiologia
           */
           string tipo;

          /**
           * Fecha del Examen
           */
           string fecha;
      }

    //TODO: modificar Foto, puede no ser una clase.
     /**
      * Clase Foto de Mascota
      */
      class Foto{

         /**
          * Direccion foto mascota: perfilMisifus.jpg
          */
         string urlFoto;
      }

    /**
     * The base system.
     */
     interface TheSystem {

        /**
         * @return the diference in time between client and server.
         */
        long getDelay(long clientTime);

     }

     //TODO: documentar bien e implementar
     /**
      * Interface para operaciones basicas en el sistema.
      */
      interface Contratos {

         /**
          * Ingresar una Ficha (paciente), historias de usuario 1.
          */
         Ficha ingresarPaciente (Ficha ficha);

         /**
          * Obtener una Ficha dado el Numero de Ficha.
          */
         Ficha obtenerPaciente (int numeroFicha);

         /**
          * Ingresar una Persona (dueño), historias de usuario 2.
          */
         Persona ingresarPersona (Persona persona);

         /**
          * Obtener una Persona dado su Rut.
          */
         Persona obtenerPersona (string rut);

         /**
          * Ingresar un Control, historias de usuario 3.
          */
         ControlMascota ingresarControl (ControlMascota control);

         /**
          * Ingresar una Foto, historias de usuario 4.
          */
          Foto ingresarFoto (Foto foto);

         /**
          * Ingresar un Examen, historias de usuario 5.
          */
         Examen ingresarExamen (Examen examen);

      }

}
