/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 14/10/2012
 * Time: 05:56 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ASintactico;

namespace AContextual
{
	/// <summary>
	/// Description of Asintactico.
	/// </summary>
	public class AContextual
	{
		public tablaSimbolos variables,tipos;
		public AContextual()
		{
			variables=new tablaSimbolos();
			tipos=new tablaSimbolos();
		}
		
		public object VisitProgramBasicAST(ProgramBasic v,object arg)
	  	{ 
	  		return null;
	  	}
	  
	 	public object VisitProgramDAST(ProgramDAST v,object arg)
	  	{
	 		v.declaraciones.visit(this,(int)arg);
        	return null;
	  	}
	  
	 	public object VisitProgramDMAST(ProgramDMAST v,object arg)
	 	{
	 		v.declaraciones.visit(this,(int)arg);
	 		v.metodos.visit(this,(int)arg);
	 		return null;
	 	}
	 	 
	 	public object VisitProgramMAST(ProgramMAST v,object arg)
	 	{
	 		v.metodos.visit(this,(int)arg);
	 		return null;
	 	}
	 	
	 	public object VisitUnDeclAST(UnDeclAST v,object arg)
	 	{
	 		v.declaracion.visit(this,(int)arg);
	 		return null;
	  	}
	  
	 	public object VisitMulDeclAST(MulDeclAST v,object arg)
	 	{
	 		v.declaracion.visit(this,(int)arg);
	 		v.declaraciones.visit(this,(int)arg);
	 		return null;
	 	}
	 	
	 	public object VisitConstDeclAST(ConstDeclAST v,object arg)
	  	{      
	  		return null;
	  	}
	  
	  	public object VisitClassDeclVAST(ClassDeclVAST v,object arg)
	  	{
	  		return null;
	  	}
	  
	 	public object VisitClassDeclBasicAST(ClassDeclBasicAST v,object arg)
	  	{
	  		return null;
	  	}
	  
	 	public object VisitDeclMulIDAST(VarDeclMulIDAST v,object arg)
	 	{
	  		return null;
	  	}
	  
	  	public object VisitDeclUnIDAST(VarDeclUnIDAST v,object arg)
	  	{
	  		return null;
	  	}
	  
	  	public object VisitMethodDeclFAST(MethodDeclFAST v,object arg)
	  	{       
	  		return null;
	  	}
	  
	  	public object VisitMethodDeclFMAST(MethodDeclFMAST v,object arg)
	  	{
	  		return null;
	  	}
	  
	 	public object VisitMethodDeclMAST(MethodDeclMAST v,object arg)
	 	{
	  		return null;
	  	}
	  
	  	public object VisitMethodDeclBasicAST(MethodDeclBasicAST v,object arg)
	  	{ 
	  		return null;
	  	}
	}	
}
