class Weather extends React.Component {
    
    constructor(props) {
        super(props);
        this.location = null;
        this.openWeatherMap = 'http://api.openweathermap.org/data/2.5/weather';
        this.openWeatherMapKey = 'fef9cd3729d1a05c2848d3ece3abdd7a';
        this.state = { weather: null, clouds: null, wind: null, main: null };
    }
    
    tick() {
        //check every 10 minutes
        
        var date = new Date();
        var checkNow = (date.getMinutes() % 10 ? false: true);

        if (!this.location) {
            //get geolocation based on IP
            //as, city, country, countryCode, isp
            //lat, lon, org, query, region, regionName, status, timezone, zip
            var getIP = 'http://ip-api.com/json/';
            $.getJSON(getIP).done($.proxy(function (location) {
                this.location = location;
                this.getWeather();
            }, this));
        } else if(checkNow){
            this.getWeather();
        }
        
    }

    getWeather() {
        
        $.proxy($.getJSON(this.openWeatherMap, {
                lat: this.location.lat,
                lon: this.location.lon,
                type: 'accurate',
                units: 'metric',
                APPID: this.openWeatherMapKey,
           }).done($.proxy(function (result) {
               //refer to https://openweathermap.org/current
               this.setState({
                   weather: result.weather[0],
                   clouds: result.clouds,
                   wind: result.wind,
                   main: result.main
               });
             },this)), this);
    }

    getIcon(icon) {
        return "http://openweathermap.org/img/w/" + icon + ".png";
    }
   

    componentDidMount() {
       
        this.ticker = setInterval(() => this.tick(), 1000);

    }
    componentWillUnMount() {
        clearInterval(this.ticker);
    }
    render() {
        if (this.state.weather) {
            return (
                <div>
                    <div className="row">
                        <div className="col-md-12 col-sm-12 city">{this.location.city} {this.location.region}, {this.location.countryCode}</div>
                    </div>
                    <div className="row">
                        <div className="col-md-6 col-sm-6 temperature align-middle text-center">{this.state.main.temp}&deg;C</div>
                        <div className="col-md-3 col-sm-3 pull-left temperatureHL">
                            <div className="row">High: {this.state.main.temp_max}&deg;C</div>
                            <div className="row">Low: {this.state.main.temp_min}&deg;C</div>
                            <Clock />
                        </div>
                        <div className="col-md-3 col-sm-3 cloud align-middle text-center">
                            <img src={this.getIcon(this.state.weather.icon)} className="image-responsive" />
                            <div className="">{this.state.weather.main}</div>
                        </div>
                    </div>
                  
                </div>
            );
        }
        return (<div className="text-center loading">Loading component...</div>);
    }
}