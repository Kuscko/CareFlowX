import axios from 'axios';
import { customElement } from 'aurelia';
import template from './referrals-list.html';

// This component fetches and displays a list of referrals
// It uses axios to make an HTTP GET request to the /api/referrals endpoint
@customElement({ name: 'referrals-list', template })
export class ReferralsList {
    referrals: any[] = [];

    async binding() {
        try {
            const { data } = await axios.get('/api/referrals');
            this.referrals = data;
        } catch (error) {
            console.error('Error fetching referrals:', error);
        }
    }
}