﻿/*
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
		public BlockAST bloque;
		public TypeAST tipo;
		public Token ident;
		public DeclarationsAST declaraciones;
		public string adornotipo;
		
		public MethodDeclMAST(DeclarationsAST decls, TypeAST tip, Token id,BlockAST blo)
		{
			bloque=blo;
			declaraciones=decls;
			ident=id;
			tipo=tip;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMethodDeclMAST(this,arg);
		}
	}
}
