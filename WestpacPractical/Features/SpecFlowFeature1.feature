Feature: SpecFlowFeature1
	test kiwisaver calculator

@Tests
Scenario Outline: Calculate Kiwisaver projected balance for Employed
	Given I am at the Kiwisaver Calculator Homepage
	And I enter current age as <currentage>
	And I select employment status as <employmentstatus>
	And I enter Salary as <annualsalary>
	And I choose member contribution as <membercontribution>
	And I choose risk profile as <riskprofile>
	When I press the Kiwisaver retirement projection
	Then the projected balance is shown

	Examples:
	| currentage | employmentstatus | annualsalary | membercontribution | riskprofile |
	| 30         | Employed         | 82000        | 4%                 | Defensive   |
	| 30         | Employed         | 82000        |                    | Conservative |

#	Scenario Outline: Calculate Kiwisaver projected balance for Self-Employed
#	Given I am at the Kiwisaver Calculator Homepage
#	And I enter current age as <currentage>
#	And I select employment status as <employmentstatus>
#	And I have current Kiwisaverbalance of <kiwisaverbalance>
#	And I voluntary contribute <contribamt>
#	And I select frequency as <frequency>
#	And I choose risk profile as <riskprofile>
#	And I enter savings goal retirement <savingsgoal>
#	When I press the Kiwisaver retirement projection
#	Then the projected balance is shown
#
#	Examples:
#	| currentage | employmentstatus | contribamt | frequency   | riskprofile  | savingsgoal | kiwisaverbalance |
#	| 45         | Self-employed    | 90         | fortnightly | Conservative | 290000       | 100000           |
#
#	Scenario Outline: Calculate Kiwisaver projected balance for Self-Employed
#	Given I am at the Kiwisaver Calculator Homepage
#	And I enter current age as <currentage>
#	And I select employment status as <employmentstatus>
#	And I have current Kiwisaverbalance of <kiwisaverbalance>
#	And I voluntary contribute <contribamt>
#	And I select frequency as <frequency>
#	And I choose risk profile as <riskprofile>
#	And I enter savings goal retirement <savingsgoal>
#	When I press the Kiwisaver retirement projection
#	Then the projected balance is shown
#
#	Examples:
#	| currentage | employmentstatus | contribamt | frequency | riskprofile | savingsgoal | kiwisaverbalance |
#	| 55         | Not employed     | 10         | Annually  | Balanced    | 200000      | 140000           |