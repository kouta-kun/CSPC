using System;
namespace SExpr {
    /// <remarks>
    /// GPLv3 (R) koutakun &lt;darkfm@vera.com.uy&gt;
    /// </remarks>
    public class StringNode : Node {
	public string value;
	public StringNode(string str) {
	    this.value = str;
	}
	public override Node getCopy() {
	    return new StringNode(this.value);
	}
	public override string ToString() {
	    return this.value;
	}
    };
};
