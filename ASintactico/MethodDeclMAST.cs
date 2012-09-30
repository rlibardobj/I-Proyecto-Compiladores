/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:34 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MethodDeclMAST.
	/// </summary>
	public class MethodDeclMAST : DeclarationAST
	{
		TypeAST tipo;
		IDAST ident;
		DeclarationsAST declaraciones;
		public MethodDeclMAST(DeclarationsAST decls, TypeAST tip, IDAST id)
		{
			declaraciones=decls;
			ident=id;
			tipo=tip;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMethodDeclMAST(this,arg);
		}
	}
}
