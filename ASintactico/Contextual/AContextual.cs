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
		public tablaSimbolos tabla;
		public AContextual()
		{
			tabla=new tablaSimbolos();
		}
		
		public object VisitProgramBasicAST(ProgramBasic v,object arg)
	  	{ 
	  		return null;
	  	}
	  
	 	public object VisitProgramDAST(ProgramDAST v,object arg)
	  	{
        	return null;
	  	}
	  
	 	public object VisitProgramDMAST(ProgramDMAST v,object arg)
	 	{
	 		return null;
	 	}
	 	 
	 	public object VisitProgramMAST(ProgramMAST v,object arg)
	 	{
	 		return null;
	 	}
	 	
	 	public object VisitUnDeclAST(UnDeclAST v,object arg)
	 	{
	  	}
	  
	 	public object VisitMulDeclAST(MulDeclAST v,object arg)
	 	{
	 	}
	}	
}
