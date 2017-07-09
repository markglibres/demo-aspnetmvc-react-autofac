class Clock extends React.Component {
    constructor(props) {
        super(props);
        //get local date
        this.state = {date: new Date()};
    }

    tictoc() {
        var date = new Date();
        this.setState({ date: date});
    }

    //pad number with trailing zeros
    padNumber(num) {
        return (num < 10 ? "0" + num : num);
    }

    displayHour() {
        var hr = this.state.date.getHours() % 12;
        hr = hr ? hr : 12;
        return this.padNumber(hr);
    }

    displayMinute() {
        return this.padNumber(this.state.date.getMinutes());
    }

    displaySecond() {
        return this.padNumber(this.state.date.getSeconds());
    }

    displayMeridian() {
        return (this.state.date.getHours() < 12 ? "AM" : "PM");
    }

    //start timer
    componentDidMount() {
        this.ticker = setInterval(() => this.tictoc(), 1000);
    }

    //dispose timer
    componentWillUnMount() {
        clearInterval(this.ticker);
    }

    //render clock
    render() {
        return (
            <div className="row clock">{this.displayHour()}:{this.displayMinute()}:{this.displaySecond()} {this.displayMeridian()}</div>    
        );
    }
}
