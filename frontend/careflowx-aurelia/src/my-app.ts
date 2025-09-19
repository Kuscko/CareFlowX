import { ReferralsList } from './pages/referrals-list';
import { ReferralDetails } from './pages/referral-details';
import { Reports } from './pages/reports';
import { route, IRouteViewModel } from '@aurelia/router';

@route({
    title: 'CareFlowX',
    routes: [
        { path: ['', 'referrals'], component: ReferralsList, title: 'Referrals' },
        { path: 'referrals/:id', component: ReferralDetails, title: 'Referral Detail' },
        { path: 'reports', component: Reports, title: 'Reports' }
    ]
})

export class MyApp implements IRouteViewModel {}