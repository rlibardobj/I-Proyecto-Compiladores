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
	/// Description of ProgramMAST.
	/// </summary>
	public class ProgramMAST : ProgramAST
	{
		public IDAST ident;
		public DeclarationsAST metodos;
		public ProgramMAST(DeclarationsAST meths,IDAST id)
		{
			ident=id;
			metodos=meths;
		}
		public override object visit(Visitor v,object arg){
			return v.VisitProgramMAST(this,arg);
		}
	}
}
