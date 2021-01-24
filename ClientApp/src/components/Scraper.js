import React, { Component } from 'react';

export class Scraper extends Component {
    static displayName = Scraper.name;

    constructor(props) {
        super(props);
        this.state = { currentCount: 0, searchText: "", searchEngines: [], numberOfPages: 0};
    }

    /*
     *Retrieve the Search Engines used by the scraper
     * */
    componentDidMount() {
        fetch('searchengine')
        .then(res => {
            if (res.status >= 400) {
                throw new Error("Server responds with error!");
            }
            return res.json();
        })
        .then(data => {
            this.setState(prevState => ({
                ...prevState,
                searchEngines: data
            }));
        })
    }

    /*
     * Trigger the scraping job
     */
    scrapeSearchEngines = () => {
        if (this.state.searchText === "") {
            alert("Please enter a text for searching");
            return;
        }

        //For each search engine, send the requests
        this.state.searchEngines.forEach((engine) => {
            let scrapingRequest = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    Url: `${engine.host}${engine.name}`,
                    SearchEngine: engine.name,
                    Keyword: this.state.searchText.toString(),
                    Pages: this.state.numberOfPages.toString(),
                })
            }
            fetch('scraper', scrapingRequest)
            .then(response => response.json())
                .then(data => {
                    alert(`${data.searchEngine}: ${data?.indexes.join(", ")}`)
            })
        });
    }

    /*
     * Update the state with the current search text 
    */
    updateSearchText = (input) => {
        this.setState(prevState => ({...prevState, searchText: input }))
    }

    /*
     * Updates the state with the number of pages
     */
    updateNumberOfPages = (input) => {
        if (input < 0 || input > 10) alert("Please enter a number from 1-10.");
        this.setState(prevState => ({ ...prevState, numberOfPages: input}))
    } 

    /*
     * Display the list of search engines used by the web scraper
     */
    displaySearchEngines = () => {
        if (this.state.searchEngines && this.state.searchEngines.length > 0)
        return (
            <div>
                <h4>This web scraper will use the following search engines:</h4>
                <ul>
                    {this.state.searchEngines?.map(x => <li>{x?.name}</li>)}
                </ul>
            </div>
        )
    }


    render() {
        return (
            <div>
                <h1>Web Scraper</h1>
                {this.displaySearchEngines()}
                <p>Please enter a search term below:</p>
                <p aria-live="polite">
                    Search Text
                    <input type="text" className="form-control" id="txt_searchText" onChange={e => this.updateSearchText(e.target.value)}></input>
                </p>
                <p aria-live="polite">
                    Number of pages to check
                    <input type="text" className="form-control" id="txt_numberOfPages" onChange={e => this.updateNumberOfPages(e.target.value)} value={this.state.numberOfPages}></input>
                </p >
                <button className="btn btn-primary" onClick={this.scrapeSearchEngines}>Search</button>
            </div>
        );
    }
}
