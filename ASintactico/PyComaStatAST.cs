/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:46 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of PyComaStatAST.
	/// </summary>
	public class PyComaStatAST : StatementAST
	{
		public PyCOMAAST pycoma;
		
		public PyComaStatAST(PyCOMAAST py)
		{
			pycoma=py;
		}
		
		
		public override object visit(Visitor v,object arg){
			return v.VisitPyComaStatAST(this,arg);
		}
	}
}
