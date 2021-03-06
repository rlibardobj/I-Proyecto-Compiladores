﻿/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:37 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulFactorAST.
	/// </summary>
	public class MulFactorAST:TermAST
	{
		public TermAST fac,facs;
		public Token operador;
		public MulFactorAST(TermAST fa, TermAST fas, Token operador)
		{
			fac=fa;
			facs=fas;
			this.operador=operador;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMulFactorAST(this,arg);
		}
	}
}
