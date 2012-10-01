/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:27 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MethodDeclBasicAST.
	/// </summary>
	public class MethodDeclBasicAST : DeclarationAST
	{
		public TypeAST tipo;
		public IDAST ident;
		
		public MethodDeclBasicAST(TypeAST tip, IDAST id)
		{
			ident=id;
			tipo=tip;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMethodDeclBasicAST(this,arg);
		}
	}
}
