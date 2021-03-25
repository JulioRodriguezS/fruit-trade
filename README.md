# fruit-trade
-This is a simple API developed in .NET CORE
-The rules are:

-Take-Home Assignment

We are expanding into the algorithmic trading of tropical fruits!
We need your help to build a REST API called fruittrade, which allows a trader to understand
the full cost of buying fruit from various countries of origin.

-Inputs

A trader using this API will specify the contemplated purchase, including:

1. The commodity (e.g. mangos)
2. The price per ton (in dollars)
3. The trade volume (in tons)

-Example

A trader who wants to know the full cost of buying 405 tons of mangos at $53 a ton would call
the calculate endpoint with the following parameters: COMMODITY=mango PRICE=53 TONS=405

-Outputs

The API must return a JSON array of all available countries of origin, and, for each:

• The country code
• The total cost of the purchase
• The breakdown of the costs between variable and trade cost, as shown in the example

The list must be sorted by total cost from highest to lowest.
