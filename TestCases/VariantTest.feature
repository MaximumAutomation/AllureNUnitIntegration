#@test
#Feature: VariantTest
#
#@Variant:5
#@Variant:6
#Scenario Outline: testing variant	
#	Given print number "<$Variant$>"	
#Examples: 
#| Col |
#| 7   |
#| 8   |
#| 9   |
#
#Scenario: testing nonvariant
#	When entered int [[var=50+20/2]]
#	Then verify int [[var]] equals 50
#	Given User navigates to url "http://amazon.com"	
#	Given print number "<Variant>"
#	Then User closes the browser
