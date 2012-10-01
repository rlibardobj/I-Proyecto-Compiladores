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
<<<<<<< HEAD
	{
		public DeclarationsAST metodos;
		
		public ProgramMAST(DeclarationsAST meths)
=======
	{
		public IDAST ident;
		public DeclarationsAST metodos;
		public ProgramMAST(DeclarationsAST meths,IDAST id)
>>>>>>> Commit.
		{
			ident=id;
			metodos=meths;
		}
		
<<<<<<< HEAD
		public override object visit(Visitor v,object arg){
			return v.VisitProgramMAST(this,arg);

=======
		public override object visit(Visitor v,object arg){
			return v.VisitProgramMAST(this,arg);
>>>>>>> Commit.
		}
	}
}
