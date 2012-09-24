/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 20/09/2012
 * Time: 01:04 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;

namespace Active
{
	/// <summary>
	/// Clase Primaria, que llena de funcionalidad al programa. Aquí se encuentran todos los procedimientos que se ejecutan desde la interfaz.
	/// </summary>
	public class Metodos
	{
		public PrincipalContext insPrincipalContext = new PrincipalContext(ContextType.Machine,"LIBARDO-SVR", "Administrador","Yenaru123");
		
		public Metodos()
		{
		}
		
		//Recibe un nombre de usuario y una contraseña necesarias para crear el nuevo usuario
		public void CrearUsuario(string UserName,string UserPassword){
			UserPrincipal insUserPrincipal = new UserPrincipal(insPrincipalContext); //Se crea una variable con el usuario
			insUserPrincipal.Name=UserName;
			insUserPrincipal.SetPassword(UserPassword); //Se setean los valores entrantes a la variable
			insUserPrincipal.Save(); //Se guarda el nuevo usuario
			insUserPrincipal.Dispose(); //Se cierra el rgeistro
			MessageBox.Show("User created.");
		}
		
		//Recibe el usuario a modificar y las variables con el nombre a mostrar y la descripcion que se van a modificar
		public void ModificarUsuario(UserPrincipal usuario, string DISP, string DESC){
			usuario.DisplayName=DISP;
			usuario.Description=DESC; //Se cambian los valores viejos por los nuevos
			usuario.Save(); // Se guarda el registro
			usuario.Dispose();
		}
		
		//Recibe el usuario al que se le reseteara la contraseña
		public void ReestablecerContraseña(UserPrincipal usuario, string PASS){
			usuario.SetPassword(PASS); //Resetea la contraseña
			usuario.Save();
			usuario.Dispose();
		}
		
		//Recibe el usuarioque see desea eliminar
		public void EliminarUsuario(UserPrincipal usuario){
				usuario.Delete(); //Se borra el registro con el usuario
				usuario.Dispose();
		}
		
		//Recibe el nombre del usuario y la contraseña que se van a autentificar
		public bool AutenticarUsuario(string UserName, string UserPassword){
			return insPrincipalContext.ValidateCredentials(UserName,UserPassword); //Retorna el valor que identifica si se autenticó exitosamente.
		}
		
		//Recibe un string con el nombre del usuario que se busca
		public UserPrincipal EncontrarUsuario(string UserName){
			UserPrincipal usr = UserPrincipal.FindByIdentity(insPrincipalContext,IdentityType.SamAccountName,UserName); // Se busca el usuario
			return usr; //Retorna el valor encontrado, que será null si no encontró alguno que coincidiera
		}
         
		//Recibe un string con el nombre del grupo, string ambito (solo permite que sea dominio) y el tipo, defecto queda seguro
		public void CrearGrupo(String nombre,String ambito, String tipo){
		  GroupPrincipal insGroupPrincipal = new GroupPrincipal(insPrincipalContext);
	      insGroupPrincipal.Name = nombre;
	      if(ambito.Equals("Global"))
	       {insGroupPrincipal.GroupScope = GroupScope.Global;}
	      else{
	            insGroupPrincipal.GroupScope = GroupScope.Local;
	          }
	      if(tipo.Equals("Seguridad"))
	         {
	      //	insGroupPrincipal.IsSecurityGroup = true;
	          }
	       else
	         {
	           //insGroupPrincipal.IsSecurityGroup = false; 
	         }
	       insGroupPrincipal.Save();
           insGroupPrincipal.Dispose();
           MessageBox.Show("Group created.");
		}

		//Realiza la busqueda grupo, y cuando encuentra si existe lo retorna
       public GroupPrincipal EncontrarGrupo(string GroupName){
			GroupPrincipal grupo = GroupPrincipal.FindByIdentity(insPrincipalContext,GroupName); // Se busca el usuario
			return grupo; //Retorna el valor encontrado, que será null si no encontró alguno que coincidiera
		}
		
		//Elimina grupo de usuarios
		public void EliminarGrupo(GroupPrincipal Grupo){
				Grupo.Delete();
				Grupo.Dispose();
		}
		
		
		//Recibe el grupo a modificar y las variables con el nombre a mostrar y la descripcion que se van a modificar
		public void ModificarGrupo(GroupPrincipal Grupo, string DISP, string DESC){
			//Grupo.DisplayName=DISP;
		    //Grupo.Description=DESC; //Se cambian los valores viejos por los nuevos
	    	//Grupo.Save(); // Se guarda el registro
		    //Grupo.Dispose();
			
			var inst = (DirectoryEntry)Grupo.GetUnderlyingObject();
			inst.Properties["description"].Add(DESC);
			//inst.Properties["Name"].Add(DISP);
            inst.CommitChanges();
            inst.Close();
		}
		
		//Ingresa usuario al grupo, recibe el usuario y el grupo
		public void ingresar_usuario_grupo(UserPrincipal usuario, GroupPrincipal grupo){
		
		if (grupo.Members.Contains(insPrincipalContext, IdentityType.SamAccountName, usuario.SamAccountName))
			{
			  MessageBox.Show(usuario.Name +  " ya es miembro del grupo " + grupo.Name);         
		    }
		else {
		      grupo.Members.Add(usuario);
              grupo.Save();
              MessageBox.Show(usuario.Name +  " insertado con éxito en el grupo " + grupo.Name);
		    }
		}
		
		
		//Elimina un usuario de un grupo, recibe usuario y el grupo
		public void eliminar_usuario_grupo(UserPrincipal usuario, GroupPrincipal grupo){
			grupo.Members.Remove(usuario);
            grupo.Save();
            MessageBox.Show(usuario.Name +  " ha sido eliminado con éxito del grupo " + grupo.Name);
		}


	}
	
	
	
}
