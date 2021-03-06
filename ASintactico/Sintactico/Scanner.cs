﻿/**
 * Scanner para la gram�tica de prueba del curso de Compiladores e Int�rpretes.
 */
using System;
using System.Text;

namespace ASintactico{


public class Scanner {
		public string errores;
	private const int YY_BUFFER_SIZE = 512;
	private const int YY_F = -1;
	private const int YY_NO_STATE = -1;
	private const int YY_NOT_ACCEPT = 0;
	private const int YY_START = 1;
	private const int YY_END = 2;
	private const int YY_NO_ANCHOR = 4;
	private const int YY_BOL = 65536;
	private const int YY_EOF = 65537;

  private int comment_count = 0;
  StringBuilder cadena = new StringBuilder();
  public Token symbol(int type) {
    return new Token(type, yyline, yychar);
  }
  public Token symbol(int type, string value) {
    return new Token(type, yyline, yychar, value);
  }
	private System.IO.TextReader yy_reader;
	private int yy_buffer_index;
	private int yy_buffer_read;
	private int yy_buffer_start;
	private int yy_buffer_end;
	private char[] yy_buffer;
	private int yychar;
	private int yyline;
	private bool yy_at_bol;
	private int yy_lexical_state;

	public Scanner (System.IO.TextReader yy_reader1) : this() {
		if (null == yy_reader1) {
			throw (new System.Exception("Error: Bad input stream initializer."));
		}
		yy_reader = yy_reader1;
	}

	private Scanner () {
		yy_buffer = new char[YY_BUFFER_SIZE];
		yy_buffer_read = 0;
		yy_buffer_index = 0;
		yy_buffer_start = 0;
		yy_buffer_end = 0;
		yychar = 0;
		yyline = 0;
		yy_at_bol = true;
		yy_lexical_state = YYINITIAL;
	}

	private bool yy_eof_done = false;
	private const int COMMENT = 1;
	private const int YYINITIAL = 0;
	private static readonly int[] yy_state_dtrans =new int[] {
		0,
		50
	};
	private void yybegin (int state) {
		yy_lexical_state = state;
	}
	private int yy_advance ()
	{
		int next_read;
		int i;
		int j;

		if (yy_buffer_index < yy_buffer_read) {
			return yy_buffer[yy_buffer_index++];
		}

		if (0 != yy_buffer_start) {
			i = yy_buffer_start;
			j = 0;
			while (i < yy_buffer_read) {
				yy_buffer[j] = yy_buffer[i];
				++i;
				++j;
			}
			yy_buffer_end = yy_buffer_end - yy_buffer_start;
			yy_buffer_start = 0;
			yy_buffer_read = j;
			yy_buffer_index = j;
			next_read = yy_reader.Read(yy_buffer,
					yy_buffer_read,
					yy_buffer.Length - yy_buffer_read);
			if ( next_read<=0) {
				return YY_EOF;
			}
			yy_buffer_read = yy_buffer_read + next_read;
		}

		while (yy_buffer_index >= yy_buffer_read) {
			if (yy_buffer_index >= yy_buffer.Length) {
				yy_buffer = yy_double(yy_buffer);
			}
			next_read = yy_reader.Read(yy_buffer,
					yy_buffer_read,
					yy_buffer.Length - yy_buffer_read);
			if ( next_read<=0) {
				return YY_EOF;
			}
			yy_buffer_read = yy_buffer_read + next_read;
		}
		return yy_buffer[yy_buffer_index++];
	}
	private void yy_move_end () {
		if (yy_buffer_end > yy_buffer_start &&
		    '\n' == yy_buffer[yy_buffer_end-1])
			yy_buffer_end--;
		if (yy_buffer_end > yy_buffer_start &&
		    '\r' == yy_buffer[yy_buffer_end-1])
			yy_buffer_end--;
	}
	private bool yy_last_was_cr=false;
	private void yy_mark_start () {
		int i;
		for (i = yy_buffer_start; i < yy_buffer_index; ++i) {
			if ('\n' == yy_buffer[i] && !yy_last_was_cr) {
				++yyline;
			}
			if ('\r' == yy_buffer[i]) {
				++yyline;
				yy_last_was_cr=true;
			} else yy_last_was_cr=false;
		}
		yychar = yychar
			+ yy_buffer_index - yy_buffer_start;
		yy_buffer_start = yy_buffer_index;
	}
	private void yy_mark_end () {
		yy_buffer_end = yy_buffer_index;
	}
	private void yy_to_mark () {
		yy_buffer_index = yy_buffer_end;
		yy_at_bol = (yy_buffer_end > yy_buffer_start) &&
		            ('\r' == yy_buffer[yy_buffer_end-1] ||
		             '\n' == yy_buffer[yy_buffer_end-1] ||
		             2028/*LS*/ == yy_buffer[yy_buffer_end-1] ||
		             2029/*PS*/ == yy_buffer[yy_buffer_end-1]);
	}
	private string yytext () {
		return (new string(yy_buffer,
			yy_buffer_start,
			yy_buffer_end - yy_buffer_start));
	}
	private int yylength () {
		return yy_buffer_end - yy_buffer_start;
	}
	private char[] yy_double (char[] buf) {
		int i;
		char[] newbuf;
		newbuf = new char[2*buf.Length];
		for (i = 0; i < buf.Length; ++i) {
			newbuf[i] = buf[i];
		}
		return newbuf;
	}
	private const int YY_E_INTERNAL = 0;
	private const int YY_E_MATCH = 1;
	private string[] yy_error_string = {
		"Error: Internal error.\n",
		"Error: Unmatched input.\n"
	};
	private void yy_error (int code,bool fatal) {
		 System.Console.Write(yy_error_string[code]);
		 System.Console.Out.Flush();
		if (fatal) {
			throw new System.Exception("Fatal Error.\n");
		}
	}
	private static int[][] unpackFromString(int size1, int size2, string st) {
		int colonIndex = -1;
		string lengthString;
		int sequenceLength = 0;
		int sequenceInteger = 0;

		int commaIndex;
		string workString;

		int[][] res = new int[size1][];
		for(int i=0;i<size1;i++) res[i]=new int[size2];
		for (int i= 0; i < size1; i++) {
			for (int j= 0; j < size2; j++) {
				if (sequenceLength != 0) {
					res[i][j] = sequenceInteger;
					sequenceLength--;
					continue;
				}
				commaIndex = st.IndexOf(',');
				workString = (commaIndex==-1) ? st :
					st.Substring(0, commaIndex);
				st = st.Substring(commaIndex+1);
				colonIndex = workString.IndexOf(':');
				if (colonIndex == -1) {
					res[i][j]=System.Int32.Parse(workString);
					continue;
				}
				lengthString =
					workString.Substring(colonIndex+1);
				sequenceLength=System.Int32.Parse(lengthString);
				workString=workString.Substring(0,colonIndex);
				sequenceInteger=System.Int32.Parse(workString);
				res[i][j] = sequenceInteger;
				sequenceLength--;
			}
		}
		return res;
	}
	private int[] yy_acpt = {
		/* 0 */ YY_NOT_ACCEPT,
		/* 1 */ YY_NO_ANCHOR,
		/* 2 */ YY_NO_ANCHOR,
		/* 3 */ YY_NO_ANCHOR,
		/* 4 */ YY_NO_ANCHOR,
		/* 5 */ YY_NO_ANCHOR,
		/* 6 */ YY_NO_ANCHOR,
		/* 7 */ YY_NO_ANCHOR,
		/* 8 */ YY_NO_ANCHOR,
		/* 9 */ YY_NO_ANCHOR,
		/* 10 */ YY_NO_ANCHOR,
		/* 11 */ YY_NO_ANCHOR,
		/* 12 */ YY_NO_ANCHOR,
		/* 13 */ YY_NO_ANCHOR,
		/* 14 */ YY_NO_ANCHOR,
		/* 15 */ YY_NO_ANCHOR,
		/* 16 */ YY_NO_ANCHOR,
		/* 17 */ YY_NO_ANCHOR,
		/* 18 */ YY_NO_ANCHOR,
		/* 19 */ YY_NO_ANCHOR,
		/* 20 */ YY_NO_ANCHOR,
		/* 21 */ YY_NO_ANCHOR,
		/* 22 */ YY_NO_ANCHOR,
		/* 23 */ YY_NO_ANCHOR,
		/* 24 */ YY_NO_ANCHOR,
		/* 25 */ YY_NO_ANCHOR,
		/* 26 */ YY_NO_ANCHOR,
		/* 27 */ YY_NO_ANCHOR,
		/* 28 */ YY_NO_ANCHOR,
		/* 29 */ YY_NO_ANCHOR,
		/* 30 */ YY_NO_ANCHOR,
		/* 31 */ YY_NO_ANCHOR,
		/* 32 */ YY_NO_ANCHOR,
		/* 33 */ YY_NO_ANCHOR,
		/* 34 */ YY_NO_ANCHOR,
		/* 35 */ YY_NO_ANCHOR,
		/* 36 */ YY_NO_ANCHOR,
		/* 37 */ YY_NO_ANCHOR,
		/* 38 */ YY_NO_ANCHOR,
		/* 39 */ YY_NO_ANCHOR,
		/* 40 */ YY_NO_ANCHOR,
		/* 41 */ YY_NO_ANCHOR,
		/* 42 */ YY_NO_ANCHOR,
		/* 43 */ YY_NO_ANCHOR,
		/* 44 */ YY_NO_ANCHOR,
		/* 45 */ YY_NO_ANCHOR,
		/* 46 */ YY_NO_ANCHOR,
		/* 47 */ YY_NO_ANCHOR,
		/* 48 */ YY_NO_ANCHOR,
		/* 49 */ YY_NO_ANCHOR,
		/* 50 */ YY_NO_ANCHOR,
		/* 51 */ YY_NO_ANCHOR,
		/* 52 */ YY_NO_ANCHOR,
		/* 53 */ YY_NOT_ACCEPT,
		/* 54 */ YY_NO_ANCHOR,
		/* 55 */ YY_NO_ANCHOR,
		/* 56 */ YY_NO_ANCHOR,
		/* 57 */ YY_NO_ANCHOR,
		/* 58 */ YY_NO_ANCHOR,
		/* 59 */ YY_NOT_ACCEPT,
		/* 60 */ YY_NO_ANCHOR,
		/* 61 */ YY_NO_ANCHOR,
		/* 62 */ YY_NO_ANCHOR,
		/* 63 */ YY_NO_ANCHOR,
		/* 64 */ YY_NOT_ACCEPT,
		/* 65 */ YY_NO_ANCHOR,
		/* 66 */ YY_NO_ANCHOR,
		/* 67 */ YY_NO_ANCHOR,
		/* 68 */ YY_NOT_ACCEPT,
		/* 69 */ YY_NO_ANCHOR,
		/* 70 */ YY_NO_ANCHOR,
		/* 71 */ YY_NOT_ACCEPT,
		/* 72 */ YY_NO_ANCHOR,
		/* 73 */ YY_NO_ANCHOR,
		/* 74 */ YY_NOT_ACCEPT,
		/* 75 */ YY_NO_ANCHOR,
		/* 76 */ YY_NO_ANCHOR,
		/* 77 */ YY_NOT_ACCEPT,
		/* 78 */ YY_NO_ANCHOR,
		/* 79 */ YY_NOT_ACCEPT,
		/* 80 */ YY_NO_ANCHOR,
		/* 81 */ YY_NOT_ACCEPT,
		/* 82 */ YY_NO_ANCHOR,
		/* 83 */ YY_NO_ANCHOR,
		/* 84 */ YY_NO_ANCHOR,
		/* 85 */ YY_NO_ANCHOR,
		/* 86 */ YY_NO_ANCHOR,
		/* 87 */ YY_NO_ANCHOR,
		/* 88 */ YY_NO_ANCHOR,
		/* 89 */ YY_NO_ANCHOR,
		/* 90 */ YY_NO_ANCHOR,
		/* 91 */ YY_NO_ANCHOR,
		/* 92 */ YY_NO_ANCHOR,
		/* 93 */ YY_NO_ANCHOR,
		/* 94 */ YY_NO_ANCHOR,
		/* 95 */ YY_NO_ANCHOR,
		/* 96 */ YY_NO_ANCHOR,
		/* 97 */ YY_NO_ANCHOR,
		/* 98 */ YY_NO_ANCHOR,
		/* 99 */ YY_NO_ANCHOR,
		/* 100 */ YY_NO_ANCHOR,
		/* 101 */ YY_NO_ANCHOR,
		/* 102 */ YY_NO_ANCHOR,
		/* 103 */ YY_NO_ANCHOR,
		/* 104 */ YY_NO_ANCHOR,
		/* 105 */ YY_NO_ANCHOR,
		/* 106 */ YY_NO_ANCHOR,
		/* 107 */ YY_NO_ANCHOR,
		/* 108 */ YY_NO_ANCHOR,
		/* 109 */ YY_NO_ANCHOR,
		/* 110 */ YY_NO_ANCHOR,
		/* 111 */ YY_NO_ANCHOR,
		/* 112 */ YY_NO_ANCHOR,
		/* 113 */ YY_NO_ANCHOR,
		/* 114 */ YY_NO_ANCHOR,
		/* 115 */ YY_NO_ANCHOR
	};
	private int[] yy_cmap = unpackFromString(1,65538,
"47:8,46:2,39,47,46,40,47:18,46,24,25:3,26,27,23,28,29,30,31,32,33,22,34,21," +
"20:9,25,35,36,37,38,25:2,19:26,44,47,45,47,19,47,4,1,6,15,3,13,19,18,12,19," +
"5,7,19,10,9,19:2,2,8,11,16,17,14,19:3,42,41,43,47:65410,0:2")[0];

	private int[] yy_rmap = unpackFromString(1,116,
"0,1,2,3,1,4,1:4,5,1,6,7,1,8,9,10,1,11,1:4,12,1:9,12:2,13,1,14,12:11,15,1:2," +
"13,16,1,17,1,18,19,20,1,21,22,14,23,24,25,26,27,28,29,30,31,32,33,34,35,36," +
"37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61," +
"62,63,12,64,65,66,67,68,69,12,70,71")[0];

	private int[][] yy_nxt = unpackFromString(72,48,
"1,2,101,102,113:2,114,113:3,88,103,54,89,115,113:2,104,113:2,3,55,4,5,56,61" +
",6,66,7,8,9,10,11,12,13,14,15,16,17,18,19,70,20,21,22,23,18,61,-1:49,113,10" +
"5,113:17,106:2,-1:46,3:2,53,-1:26,59:40,-1:38,27,-1:49,28,-1:44,29,-1:3,64," +
"-1:50,30,-1:47,31,-1:47,32,-1:49,57,-1:9,113:19,106:2,-1:46,36:2,-1:27,64:2" +
"9,68,64:3,71,64:4,-1,38,64:7,1,58:29,73,58:3,76,58:4,57,62,58:7,-1,113:12,2" +
"4,113:6,106:2,-1:63,25,-1:11,58:29,79,58:3,81,58:4,-1,58:8,-1:23,37,-1:25,1" +
"13:13,34,113:5,106:2,-1:27,58:29,79,58:3,81,58:4,57,58:8,-1,58:29,63,58:3,8" +
"1,58:4,-1,58:8,-1,113,35,113:17,106:2,-1:53,26,-1:21,58:29,79,58:3,67,58:4," +
"-1,58:8,-1,64:29,74,64:3,-1,64:4,-1,64:8,-1,113:14,39,113:4,106:2,-1:67,33," +
"-1:7,64:29,-1,64:3,77,64:4,-1,64:8,-1,113:2,40,113:16,106:2,-1:27,58:29,63," +
"58:3,51,58:4,-1,58:8,-1,64:29,74,64:3,71,64:4,-1,38,64:7,-1,113:2,41,113:16" +
",106:2,-1:27,58:29,52,58:3,67,58:4,-1,58:8,-1,64:29,68,64:3,77,64:4,-1,38,6" +
"4:7,-1,113:14,42,113:4,106:2,-1:27,58:29,63,58:3,-1,58:4,-1,58:8,-1,113:4,4" +
"3,113:14,106:2,-1:27,58:29,-1,58:3,67,58:4,-1,58:8,-1,113:7,44,113:11,106:2" +
",-1:27,113:10,45,113:8,106:2,-1:27,113:2,46,113:16,106:2,-1:27,113:2,47,113" +
":16,106:2,-1:27,113:2,48,113:16,106:2,-1:27,113:9,49,113:9,106:2,-1:27,113:" +
"2,60,113:16,106:2,-1:27,113:3,109,113:4,65,113:10,106:2,-1:27,113:3,69,113:" +
"6,112,113:8,106:2,-1:27,113:7,72,113:11,106:2,-1:27,113:15,75,113:3,106:2,-" +
"1:27,113:11,78,113:7,106:2,-1:27,113:3,80,113:15,106:2,-1:27,113:7,82,113:1" +
"1,106:2,-1:27,113:7,83,113:11,106:2,-1:27,113:7,84,113:11,106:2,-1:27,113:1" +
"0,85,113:8,106:2,-1:27,113:6,86,113:12,106:2,-1:27,113,87,113:17,106:2,-1:2" +
"7,113:2,90,113:16,106:2,-1:27,113:6,91,113:12,106:2,-1:27,113,92,113:17,106" +
":2,-1:27,113:8,93,113:10,106:2,-1:27,113:2,94,113:16,106:2,-1:27,113:3,95,1" +
"13:15,106:2,-1:27,113:9,96,113:9,106:2,-1:27,113:6,97,113:12,106:2,-1:27,11" +
"3:11,98,113:7,106:2,-1:27,113:11,99,113:7,106:2,-1:27,113:15,100,113:3,106:" +
"2,-1:27,113:6,107,113,108,113:10,106:2,-1:27,113,110,113:15,111,113,106:2,-" +
"1:26");

	public Token nextToken ()
 {
		int yy_lookahead;
		int yy_anchor = YY_NO_ANCHOR;
		int yy_state = yy_state_dtrans[yy_lexical_state];
		int yy_next_state = YY_NO_STATE;
		int yy_last_accept_state = YY_NO_STATE;
		bool yy_initial = true;
		int yy_this_accept;

		yy_mark_start();
		yy_this_accept = yy_acpt[yy_state];
		if (YY_NOT_ACCEPT != yy_this_accept) {
			yy_last_accept_state = yy_state;
			yy_mark_end();
		}
		while (true) {
			if (yy_initial && yy_at_bol) yy_lookahead = YY_BOL;
			else yy_lookahead = yy_advance();
			yy_next_state = YY_F;
			yy_next_state = yy_nxt[yy_rmap[yy_state]][yy_cmap[yy_lookahead]];
			if (YY_EOF == yy_lookahead && true == yy_initial) {

	return symbol(sym.EOF);
			}
			if (YY_F != yy_next_state) {
				yy_state = yy_next_state;
				yy_initial = false;
				yy_this_accept = yy_acpt[yy_state];
				if (YY_NOT_ACCEPT != yy_this_accept) {
					yy_last_accept_state = yy_state;
					yy_mark_end();
				}
			}
			else {
				if (YY_NO_STATE == yy_last_accept_state) {
					throw (new System.Exception("Lexical Error: Unmatched Input."));
				}
				else {
					yy_anchor = yy_acpt[yy_last_accept_state];
					if (0 != (YY_END & yy_anchor)) {
						yy_move_end();
					}
					yy_to_mark();
					switch (yy_last_accept_state) {
					case 1:
						break;
					case -2:
						break;
					case 2:
						{ return symbol(sym.ID,yytext()); }
					case -3:
						break;
					case 3:
						{ return symbol(sym.NUM,yytext()); }
					case -4:
						break;
					case 4:
						{ return symbol(sym.PUNTO); }
					case -5:
						break;
					case 5:
						{ errores=errores+"Error Léxico. Caracter No permitido: "+yytext()+". Linea: "+Convert.ToString(yyline)+".Columna: "+ Convert.ToString(yychar)+"\n";
						break;}
					case -6:
						break;
					case 6:
						{ return symbol(sym.MOD); }
					case -7:
						break;
					case 7:
						{ return symbol(sym.PARENi); }
					case -8:
						break;
					case 8:
						{ return symbol(sym.PARENd); }
					case -9:
						break;
					case 9:
						{ return symbol(sym.MULT); }
					case -10:
						break;
					case 10:
						{ return symbol(sym.SUM); }
					case -11:
						break;
					case 11:
						{ return symbol(sym.COMA); }
					case -12:
						break;
					case 12:
						{ return symbol(sym.SUB); }
					case -13:
						break;
					case 13:
						{ return symbol(sym.DIV); }
					case -14:
						break;
					case 14:
						{ return symbol(sym.PyCOMA); }
					case -15:
						break;
					case 15:
						{ return symbol(sym.MENOR); }
					case -16:
						break;
					case 16:
						{ return symbol(sym.ASIGN); }
					case -17:
						break;
					case 17:
						{ return symbol(sym.MAYOR); }
					case -18:
						break;
					case 18:
						break;
					case -19:
						break;
					case 19:
						break;
					case -20:
						break;
					case 20:
						{ return symbol(sym.LLAVEi); }
					case -21:
						break;
					case 21:
						{ return symbol(sym.LLAVEd); }
					case -22:
						break;
					case 22:
						{ return symbol(sym.CORCHi); }
					case -23:
						break;
					case 23:
						{ return symbol(sym.CORCHd); }
					case -24:
						break;
					case 24:
						{ return symbol(sym.IF); }
					case -25:
						break;
					case 25:
						{ return symbol(sym.DIST); }
					case -26:
						break;
					case 26:
						{ return symbol(sym.Y); }
					case -27:
						break;
					case 27:
						{ return symbol(sym.AUM); }
					case -28:
						break;
					case 28:
						{ return symbol(sym.DEC); }
					case -29:
						break;
					case 29:
						{ yybegin(COMMENT); comment_count = comment_count + 1;break; }
					case -30:
						break;
					case 30:
						{ return symbol(sym.MENORi); }
					case -31:
						break;
					case 31:
						{ return symbol(sym.IGUAL); }
					case -32:
						break;
					case 32:
						{ return symbol(sym.MAYORi); }
					case -33:
						break;
					case 33:
						{ return symbol(sym.O); }
					case -34:
						break;
					case 34:
						{ return symbol(sym.NEW); }
					case -35:
						break;
					case 35:
						{ return symbol(sym.FOR); }
					case -36:
						break;
					case 36:
						{ return symbol(sym.NUM,yytext()); }
					case -37:
						break;
					case 37:
						{ return symbol(sym.CHAR,yytext()); }
					case -38:
						break;
					case 38:
						break;
					case -39:
						break;
					case 39:
						{ return symbol(sym.READ); }
					case -40:
						break;
					case 40:
						{ return symbol(sym.ELSE); }
					case -41:
						break;
					case 41:
						{ return symbol(sym.TRUE); }
					case -42:
						break;
					case 42:
						{ return symbol(sym.VOID); }
					case -43:
						break;
					case 43:
						{ return symbol(sym.BREAK); }
					case -44:
						break;
					case 44:
						{ return symbol(sym.CLASS); }
					case -45:
						break;
					case 45:
						{ return symbol(sym.CONST); }
					case -46:
						break;
					case 46:
						{ return symbol(sym.FALSE); }
					case -47:
						break;
					case 47:
						{ return symbol(sym.WRITE); }
					case -48:
						break;
					case 48:
						{ return symbol(sym.WHILE); }
					case -49:
						break;
					case 49:
						{ return symbol(sym.RETURN); }
					case -50:
						break;
					case 50:
						break;
					case -51:
						break;
					case 51:
						{ 
	comment_count = comment_count - 1; 
	if (comment_count == 0) {
    		yybegin(YYINITIAL);
	}
	else if (comment_count < 0) {
		 errores=errores+"Error Léxico. Comentario anidado mal cerrado.\n";
	}
	break;
}
					case -52:
						break;
					case 52:
						{ comment_count = comment_count + 1;break; }
					case -53:
						break;
					case 54:
						{ return symbol(sym.ID,yytext()); }
					case -54:
						break;
					case 55:
						{ return symbol(sym.NUM,yytext()); }
					case -55:
						break;
					case 56:
						{ errores=errores+"Error Léxico. Caracter No permitido: "+yytext()+". Linea: "+Convert.ToString(yyline)+".Columna: "+ Convert.ToString(yychar)+"\n";
						break;}
					case -56:
						break;
					case 57:
						break;
					case -57:
						break;
					case 58:
						break;
					case -58:
						break;
					case 60:
						{ return symbol(sym.ID,yytext()); }
					case -59:
						break;
					case 61:
						{ errores=errores+"Error Léxico. Caracter no permitido: "+yytext()+". Linea: "+Convert.ToString(yyline)+".Columna: "+ Convert.ToString(yychar)+"\n";
						break;}

					case -60:
						break;
					case 62:
						break;
					case -61:
						break;
					case 63:
						break;
					case -62:
						break;
					case 65:
						{ return symbol(sym.ID,yytext()); }
					case -63:
						break;
					case 66:
						{ errores=errores+"Error Léxico. Caracter No permitido: "+yytext()+". Linea: "+Convert.ToString(yyline)+".Columna: "+ Convert.ToString(yychar)+"\n";
						break;}
					case -64:
						break;
					case 67:
						break;
					case -65:
						break;
					case 69:
						{ return symbol(sym.ID,yytext()); }
					case -66:
						break;
					case 70:
						{ errores=errores+"Error Léxico. Caracter No permitido: "+yytext()+". Linea: "+Convert.ToString(yyline)+".Columna: "+ Convert.ToString(yychar)+"\n";
						break;}
					case -67:
						break;
					case 72:
						{ return symbol(sym.ID,yytext()); }
					case -68:
						break;
					case 73:
						{ errores=errores+"Error Léxico. Caracter No permitido: "+yytext()+". Linea: "+Convert.ToString(yyline)+".Columna: "+ Convert.ToString(yychar)+"\n";
						break;}
					case -69:
						break;
					case 75:
						{ return symbol(sym.ID,yytext()); }
					case -70:
						break;
					case 76:
						{ errores=errores+"Error Léxico. Caracter No permitido: "+yytext()+". Linea: "+Convert.ToString(yyline)+".Columna: "+ Convert.ToString(yychar)+"\n";
						break;}
					case -71:
						break;
					case 78:
						{ return symbol(sym.ID,yytext()); }
					case -72:
						break;
					case 80:
						{ return symbol(sym.ID,yytext()); }
					case -73:
						break;
					case 82:
						{ return symbol(sym.ID,yytext()); }
					case -74:
						break;
					case 83:
						{ return symbol(sym.ID,yytext()); }
					case -75:
						break;
					case 84:
						{ return symbol(sym.ID,yytext()); }
					case -76:
						break;
					case 85:
						{ return symbol(sym.ID,yytext()); }
					case -77:
						break;
					case 86:
						{ return symbol(sym.ID,yytext()); }
					case -78:
						break;
					case 87:
						{ return symbol(sym.ID,yytext()); }
					case -79:
						break;
					case 88:
						{ return symbol(sym.ID,yytext()); }
					case -80:
						break;
					case 89:
						{ return symbol(sym.ID,yytext()); }
					case -81:
						break;
					case 90:
						{ return symbol(sym.ID,yytext()); }
					case -82:
						break;
					case 91:
						{ return symbol(sym.ID,yytext()); }
					case -83:
						break;
					case 92:
						{ return symbol(sym.ID,yytext()); }
					case -84:
						break;
					case 93:
						{ return symbol(sym.ID,yytext()); }
					case -85:
						break;
					case 94:
						{ return symbol(sym.ID,yytext()); }
					case -86:
						break;
					case 95:
						{ return symbol(sym.ID,yytext()); }
					case -87:
						break;
					case 96:
						{ return symbol(sym.ID,yytext()); }
					case -88:
						break;
					case 97:
						{ return symbol(sym.ID,yytext()); }
					case -89:
						break;
					case 98:
						{ return symbol(sym.ID,yytext()); }
					case -90:
						break;
					case 99:
						{ return symbol(sym.ID,yytext()); }
					case -91:
						break;
					case 100:
						{ return symbol(sym.ID,yytext()); }
					case -92:
						break;
					case 101:
						{ return symbol(sym.ID,yytext()); }
					case -93:
						break;
					case 102:
						{ return symbol(sym.ID,yytext()); }
					case -94:
						break;
					case 103:
						{ return symbol(sym.ID,yytext()); }
					case -95:
						break;
					case 104:
						{ return symbol(sym.ID,yytext()); }
					case -96:
						break;
					case 105:
						{ return symbol(sym.ID,yytext()); }
					case -97:
						break;
					case 106:
						{ return symbol(sym.ID,yytext()); }
					case -98:
						break;
					case 107:
						{ return symbol(sym.ID,yytext()); }
					case -99:
						break;
					case 108:
						{ return symbol(sym.ID,yytext()); }
					case -100:
						break;
					case 109:
						{ return symbol(sym.ID,yytext()); }
					case -101:
						break;
					case 110:
						{ return symbol(sym.ID,yytext()); }
					case -102:
						break;
					case 111:
						{ return symbol(sym.ID,yytext()); }
					case -103:
						break;
					case 112:
						{ return symbol(sym.ID,yytext()); }
					case -104:
						break;
					case 113:
						{ return symbol(sym.ID,yytext()); }
					case -105:
						break;
					case 114:
						{ return symbol(sym.ID,yytext()); }
					case -106:
						break;
					case 115:
						{ return symbol(sym.ID,yytext()); }
					case -107:
						break;
					default:
						yy_error(YY_E_INTERNAL,false);break;
					}
					yy_initial = true;
					yy_state = yy_state_dtrans[yy_lexical_state];
					yy_next_state = YY_NO_STATE;
					yy_last_accept_state = YY_NO_STATE;
					yy_mark_start();
					yy_this_accept = yy_acpt[yy_state];
					if (YY_NOT_ACCEPT != yy_this_accept) {
						yy_last_accept_state = yy_state;
						yy_mark_end();
					}
				}
			}
		}
	}
}
}
