﻿/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:25 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of UnIDVarDeclAST.
	/// </summary>
	public class VarDeclUnIDAST : DeclarationAST
	{
		public TypeAST tipo;
		public TerminalesAST identificador;
		
		public VarDeclUnIDAST(TerminalesAST id, TypeAST tip)
		{
			identificador=id;
			tipo=tip;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitDeclUnIDAST(this,arg);
		}
	}
}