/*
 * Created by SharpDevelop.
 * User: HMSS
 * Date: 23/09/2012
 * Time: 09:33 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of MulTermMExprAST.
	/// </summary>
	public class MulTermMExprAST:ExprAST
	{
		ExprAST term,terms;
		public MulTermMExprAST(ExprAST ter, ExprAST ters)
		{
			term=ter;
			terms=ters;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitMulTermMExprAST(this,arg);
		}
	}
}
