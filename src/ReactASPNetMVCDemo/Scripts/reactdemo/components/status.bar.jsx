var StatusBar = React.createClass({
    render: function () {
        if (this.props.show)
        {
            return (
                <div className="row">
                    <div className={this.props.className}>
                        <strong>{this.props.message}</strong>
                    </div>
                </div>
            )
        }
        return null;
    }
});