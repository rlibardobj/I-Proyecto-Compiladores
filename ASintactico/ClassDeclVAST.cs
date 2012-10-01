/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:26 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of ClassDeclVAST.
	/// </summary>
	public class ClassDeclVAST : DeclarationAST
	{
		public DeclarationsAST declaraciones;
		public TerminalesAST ident;
		
		public ClassDeclVAST(DeclarationsAST decls,TerminalesAST id)
		{
			declaraciones=decls;
			ident=id;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitClassDeclVAST(this,arg);
		}
	}
}
