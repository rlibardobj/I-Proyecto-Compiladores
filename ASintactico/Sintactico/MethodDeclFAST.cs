/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:33 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MethodDeclFAST.
	/// </summary>
	public class MethodDeclFAST : DeclarationAST
	{
		public BlockAST bloque;
		public FormParsAST parametros;
		public TypeAST tipo;
		public Token ident;
		public string adornotipo;
		
		public MethodDeclFAST(FormParsAST par,TypeAST tip, Token id,BlockAST blo)
		{
			bloque=blo;
			parametros=par;
			ident=id;
			tipo=tip;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMethodDeclFAST(this,arg);
		}
	}
}
