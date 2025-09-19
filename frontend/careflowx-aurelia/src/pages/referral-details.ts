import axios from "axios";
import type { IRouteViewModel } from "@aurelia/router";
import { customElement } from "aurelia";
import template from './referral-details.html';

// This component displays and allows editing of referral details
// It uses route parameters to load specific referral data from the backend API
@customElement({ name: 'referral-details', template})
export class ReferralDetails implements IRouteViewModel {
    static parameters: string[] = ['id'];
    id: number | null = null;
    model = { patientName: '', provider: '', status: '', notes: '' };

    async canLoad(params: { id: string }): Promise<boolean> {
        this.id = parseInt(params.id, 10);
        if (isNaN(this.id)) {
            return false;
        }
        try {
            const { data } = await axios.get(`/api/referrals/${this.id}`);
            this.model = data;
            return true;
        } catch (error) {
            console.error('Error fetching referral details:', error);
            return false;
        }
    }

    async canSave(): Promise<boolean> {
        if (this.id === null) {
            return false;
        }
        try {
            await axios.post(`/api/referrals/${this.id}`, this.model);
            window.location.hash = '#/referrals';
            return true;
        } catch (error) {
            console.error('Error saving referral details:', error);
            return false;
        }
    }

    async canSummarize(): Promise<boolean> {
        if (this.id === null) {
            return false;
        }
        try {
            const { data } = await axios.post(`/api/ai/summarize`, { text: this.model.notes, tone: 'clinical' });
            alert(`AI Summary: ` + (data.summary ?? JSON.stringify(data)));
            return true;
        } catch (error) {
            console.error('Error fetching referral summary:', error);
            return false;
        }
    }
    
}
