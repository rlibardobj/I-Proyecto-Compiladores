/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 09:53 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ProgramDMAST.
	/// </summary>
	public class ProgramDMAST : ProgramAST
	{ 
		public IDAST ident;
		public DeclarationsAST declaraciones;
		public DeclarationsAST metodos;
		public ProgramDMAST(DeclarationsAST decls,DeclarationsAST meths,IDAST id)
		{
			ident=id;
			declaraciones=decls;
			metodos=meths;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitProgramDMAST(this,arg);

		}
	}
}
