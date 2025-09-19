import { customElement } from 'aurelia';
import axios from 'axios';
import template from './reports.html';

// This component fetches and displays a summary report
// It uses axios to make an HTTP GET request to the /api/report/summary endpoint
@customElement({ name: 'reports', template })
export class Reports {
  summary: any[] = [];
  async binding() {
    const { data } = await axios.get('/api/report/summary');
    this.summary = data;
  }
}
