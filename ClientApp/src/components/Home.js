import React, { Component } from 'react';

export class Home extends Component {
  static displayName = Home.name;

  render () {
    return (
      <div>
            <h1>InfoTrack Development Challenge</h1>
            <h5>by: Dexter Galvez</h5>
            <p>
                This static website is created in ASP.NET Core (using the React template).
            </p>
            <p>
                The list of Search Engines supported are stored in an Azure Storage Table to allow for extension.
            </p>
            <p>
                Please click the Scrape button in the navigation to get started.
            </p>
      </div>
    );
  }
}
