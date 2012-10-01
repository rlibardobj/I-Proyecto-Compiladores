/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:32 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MethodDeclFMAST.
	/// </summary>
	public class MethodDeclFMAST : DeclarationAST
	{
		public TypeAST tipo;
		public IDAST ident;
		public FormParsAST parametros;
		public DeclarationsAST declaraciones;
		public BlockAST bloque;
		
		public MethodDeclFMAST(FormParsAST par, DeclarationsAST decls, TypeAST tip, IDAST id,BlockAST blo)
		{
			bloque=blo;
			parametros=par;
			declaraciones=decls;
			ident=id;
			tipo=tip;
		}

		public override object visit(Visitor v,object arg){
			return v.VisitMethodDeclFMAST(this,arg);
		}
	}
}
