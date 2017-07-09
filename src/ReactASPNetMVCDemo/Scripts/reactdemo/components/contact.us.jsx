var ContactUs = React.createClass({
    getInitialState: function () {
        return {
            name: '', email: '', message: '', status: ''
        };
    },
    handleNameChange: function (e) {
        this.setState({ name: e.target.value });
        this.clearStatus();
    },
    handleEmailChange: function (e) {
        this.setState({ email: e.target.value });
        this.clearStatus();
    },
    handleMessageChange: function (e) {
        this.setState({ message: e.target.value });
        this.clearStatus();
    },
    clearStatus: function () {
        this.setState({ status: '' });
    },
    handleSubmit: function (e) {
        e.preventDefault();

        var data = {
            Name: this.state.name.trim(),
            Email: this.state.email.trim(),
            Message: this.state.message.trim()
        };
        $.ajax({
            type: "POST",
            url: this.props.submitUrl,
            data: data,
            success: this.handleSuccess,
            dataType: "json"
        });
        
    },
    handleSuccess: function (result) {
        if (result.Success) {
            this.setState({ name: '', email: '', message: '' });
        }
        this.setState({ status: result.Message });
    },
    render: function () {
        return (
            <form className="contactForm" onSubmit={this.handleSubmit}>
                <div className="row form-group">
                    <div className="input-group form-inline">
                        <label htmlFor="name">Name</label>
                        <input className="form-control" type="text" value={this.state.name} id="name" onChange={this.handleNameChange} placeholder="Your name" />
                    </div>
                    <div className="input-group form-inline">
                        <label htmlFor="email">Email</label>
                        <input className="form-control" type="email" value={this.state.email} id="email" onChange={this.handleEmailChange} placeholder="Your email"/>
                    </div>
                </div>
                <div className="row form-group">
                    <div className="input-group contact-message">
                        <label htmlFor="message">Message</label>
                        <textarea className="form-control contact-message" id="message" value={this.state.message} rows="10" onChange={this.handleMessageChange} placeholder="Your message"></textarea>
                        
                    </div>
                </div>
                <div className="row form-group">
                    <input type="submit" value="Submit" className="pull-right" />
                </div>
                <StatusBar show={this.state.status != ''} message={this.state.status} className="alert alert-success fade in" /> 
            </form>
        )
        
    }
});

