﻿/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:34 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulTermExprAST.
	/// </summary>
	public class MulTermExprAST:ExprAST
	{
		public ExprAST term,terms;
		
		public MulTermExprAST(ExprAST ter, ExprAST ters)
		{
			term=ter;
			terms=ters;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMulTermExprAST(this,arg);
		}
	}
}
