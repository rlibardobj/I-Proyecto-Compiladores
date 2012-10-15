/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 08:44 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of UnDeclAST.
	/// </summary>
	public class UnDeclAST : DeclarationsAST
	{
		public DeclarationAST declaracion;
		
		public UnDeclAST(DeclarationAST decl){
			declaracion=decl;
	}
		
		
	public override object visit(Visitor v,object arg){
			return v.VisitUnDeclAST(this,arg);
		}	
		
	}
}
