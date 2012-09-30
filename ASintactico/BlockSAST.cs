/*
 * Created by SharpDevelop.
 * User: rlibardobj
 * Date: 23/09/2012
 * Time: 10:40 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ASintactico
{
	/// <summary>
	/// Description of BlockSAST.
	/// </summary>
	public class BlockSAST : BlockAST
	{
		StatementsAST statement;
		public BlockSAST(StatementsAST sta)
		{
			statement = sta;
		}
		
		public override object visit(Visitor v,object arg){
			return v.VisitBlockSAST(this,arg);
		}
	}
}
