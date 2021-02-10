# random notes for myself

Per Twitch Webhook documentation:

 ```
Limits: By default, each client ID can have at most 10,000 subscriptions. Also, you can subscribe to the same topic at most 3 times.
```

I think this is why the *popular* dicsord bots that announces twitch streams struggles to announce some streamers, as these bots are rapidly filling up their subscription limits for twitch. An easy solution for other streamers to reliably have their streamers announced automatically is to host their own bot that would announce their live status, however there doesn't seem to be much available open source bots that does this.