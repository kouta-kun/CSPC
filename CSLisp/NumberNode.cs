using System;
namespace SExpr {
    /// <remarks>
    /// GPLv3 (R) koutakun &lt;darkfm@vera.com.uy&gt;
    /// </remarks>
    public class NumberNode : Node {
	public double value;
    public NumberNode(double i) {
	    this.value = i;
	}
	public override Node getCopy() {
	    return new NumberNode(this.value);
	}
	public override string ToString() {
	    return this.value.ToString();
	}
    };
};
