using System;
namespace SExpr {
    /// <remarks>
    /// GPLv3 (R) koutakun &lt;darkfm@vera.com.uy&gt;
    /// </remarks>
    public static class Parser {
	public static Tuple<string, int> ExtractList(string line) {
	    int balance = 1;
	    for (int i = 1; i < line.Length; i++)
	    {
		if(line[i] == '(')
		    balance++;
		if(line[i] == ')') {
		    balance--;
		    if (balance == 0)
			return Tuple.Create(line.Substring(0, i+1), i);
		}
	    }
	    return null;
	}
	public static Tuple<string, int> ExtractString(string line) {
	    if (line[0] == '"') {
		var idx = line.IndexOf('"', 1);
		return Tuple.Create(line.Substring(1, idx-1), idx);
	    } else {
		var idx = line.IndexOf(' ');
		return Tuple.Create(line.Substring(0, idx), idx);
	    }
	}
	public static ListNode ParseString(string line) {
	    ListNode list = new ListNode(true);
	    if(!(line[0] == '(' && line[line.Length-1] == ')')) {
		return null;
	    }
	    line = line.Substring(1, line.Length-2);
	    while(!String.IsNullOrEmpty(line)) {
		if(line[0] == ' ') line = line.Substring(1);
		if(line[0] == '(') {
		    var sublist = ExtractList(line);
		    list.addNode(ParseString(sublist.Item1));
		    if(sublist.Item2 == -1)
			break;
		    line = line.Substring(sublist.Item2 + 1);
		} else if(line[0] == '"') {
		    var substr = ExtractString(line);
		    list.addNode(new StringNode(substr.Item1));
		    if(substr.Item2 == -1) break;
		    line = line.Substring(substr.Item2 + 1);
		} else if(line[0] == '\'') {
		    var substr = ExtractString(line);
		    list.addNode(new SymbolNode
				 (substr.Item1.Substring(1))
			);
		    if(substr.Item2 == -1) break;
		    line = line.Substring(substr.Item2 + 1);
		} else {
		    var idx = line.IndexOf(' ');
		    var n = (idx!=-1) ? line.Substring(0, idx) : line;
		    try {
			list.addNode(new NumberNode(Double.Parse(n)));
		    } catch (Exception) {
			list.addNode(new SymbolNode(n));
		    }
		    if(idx == -1) break;
		    line = line.Substring(idx + 1);
		}
	    }
	    return list;
	}
    };
}
