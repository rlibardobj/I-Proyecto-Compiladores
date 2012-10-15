/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:45 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of BlockStatAST.
	/// </summary>
	public class BlockStatAST : StatementAST
	{
		public BlockAST bloque;
		
		public BlockStatAST(BlockAST blq)
		{
			bloque=blq;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitBlockStatAST(this,arg);
		}
	}
}
