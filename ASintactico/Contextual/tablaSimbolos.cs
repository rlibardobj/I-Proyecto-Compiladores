/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 14/10/2012
 * Time: 05:57 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using ASintactico;
using AContextual;

namespace AContextual
{
	/// <summary>
	/// Description of tablaSimbolos.
	/// </summary>
	public class tablaSimbolos
	{
		LinkedList<nodoTabla> tabla;
		int nivel;
		
		
		public tablaSimbolos()
		{
			tabla=new LinkedList<nodoTabla>();
			nivel=0;
		}
		
		
		//retorna false si ya existe
		public bool enter(String nombre,string var, AST pdec)
		{
			LinkedList<nodoTabla> temp;
			temp = tabla;
			int nivel_actual = nivel;
			bool existe = false;
			nodoTabla nn = new nodoTabla(nombre,var,pdec,nivel);
			
			while(nivel_actual == temp.First.Value.nivel)
			{
				if(temp.First.Value.nombre == nombre)
				{
					existe=true;
				}
				temp.RemoveFirst();
			}
			
			if(existe)
			{
				//("Ya existe la variable que se desea crear");
				return false;
			}
			else{
				tabla.AddFirst(nn);
				return true;
			}
			
		}
		
		public nodoTabla retrieve(String nombre)
		{
			LinkedList<nodoTabla> temp;
			temp = tabla;
			int nivel_actual = nivel;
			bool existe = false;
			
			while(temp.First != null)
			{
				if(temp.First.Value.nombre == nombre)
				{
					existe=true;
					break;
				}
				temp.RemoveFirst();
			}
			if(existe)
			{
				return temp.First.Value;
			}
			else {return null;}
		}
		
		public nodoTabla retrieve(String nombre,string var)
		{
			LinkedList<nodoTabla> temp;
			temp = tabla;
			int nivel_actual = nivel;
			bool existe = false;
			
			while(temp.First != null)
			{
				if((temp.First.Value.nombre == nombre)&&(temp.First.Value.variable == var))
				{
					existe=true;
					break;
				}
				temp.RemoveFirst();
			}
			if(existe)
			{
				return temp.First.Value;
			}
			else {return null;}
		}
		
		public nodoTabla retrieven(String nombre)
		{
			LinkedList<nodoTabla> temp;
			temp = tabla;
			int nivel_actual = nivel;
			bool existe = false;
			
			while(temp.First != null)
			{
				if(temp.First.Value.nombre == nombre)
				{
					existe=true;
					break;
				}
				temp.RemoveFirst();
			}
			if(existe)
			{
				return temp.First.Value;
			}
			else {return null;}
		}
		
		public nodoTabla retrieven(String nombre,string var)
		{
			LinkedList<nodoTabla> temp;
			temp = tabla;
			int nivel_actual = nivel;
			bool existe = false;
			
			while(temp.First != null)
			{
				if((temp.First.Value.nombre == nombre)&&(temp.First.Value.variable == var))
				{
					existe=true;
					break;
				}
				temp.RemoveFirst();
			}
			if(existe)
			{
				return temp.First.Value;
			}
			else {return null;}
		}
		
		public void open_scope()
		{
			nivel = nivel++;
		}
		
		
		public void close_scope()
		{
			int temp = nivel;
			
			while(temp == nivel)
			{
				tabla.RemoveFirst();
			}
			nivel = nivel--;
		}
		
		public string primero(){
			return tabla.First.Value.nombre;
		}
		
	}
}
