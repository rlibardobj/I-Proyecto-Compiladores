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
	/// Description of ProgramDAST.
	/// </summary>
	public class ProgramDAST : ProgramAST
	{
		public DeclarationsAST declaraciones;
<<<<<<< HEAD
		IDAST ident;
		public ProgramDAST(DeclarationsAST decls,IDAST id)
=======
		
		public ProgramDAST(DeclarationsAST decls)
>>>>>>> origin/master
		{
			ident=id;
			declaraciones=decls;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitProgramDAST(this,arg);
		}
	}
}
