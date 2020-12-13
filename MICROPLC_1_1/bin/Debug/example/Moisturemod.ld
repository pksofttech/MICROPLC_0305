# LD FORMAT copy Form LDMICRO#
HARDWARE
Not setting
IO LIST
Ach1 at -
Ach2 at -
Ach3 at -
Ach4 at -
Ach5 at -
Ach6 at -
Ach7 at -
Ach8 at -
Xnew at -
YA_PWR at -
Yhbeat_led at -
Yzone1_led at -
Yzone2_led at -
Yzone3_led at -
Yzone4_led at -
Yzone5_led at -
Yzone6_led at -
Yzone7_led at -
Yzone8_led at -
END
PROGRAM
RUNG
	COMMENT                            HEART BEAT LED LOGIC
END
RUNG
	CONTACTS Rhbeat 0 0 0
	TON Thbeat_on 500000
	TOF Thbeat_off 500000
	COIL Rhbeat 1 0 0 0
END
RUNG
	CONTACTS Rhbeat 0 0 0
	COIL Yhbeat_led 0 0 0 0
END
RUNG
	COMMENT               This is the osc for the analog inputs
END
RUNG
	CONTACTS Rac_osc 0 0 0
	TON Tac_osc_on 50000
	TOF Tac_osc_off 50000
	COIL Rac_osc 1 0 0 0
END
RUNG
	CONTACTS Rac_osc 0 0 0
	COIL YA_PWR 0 0 0 0
END
RUNG
		CONTACTS Xnew 0 0 0
	PARALLEL
		SHIFT_REGISTER ch 3 
		MOVE ch0 '1'
		COIL Rrecvd 0 0 0 0
	END
END
RUNG
	EQU ch2 'Q'
	EQU ch1 'A'
	PARALLEL
		SERIES
			EQU ch0 '1'
			COIL Rzone1_sel 0 1 0 0
		END
		SERIES
			EQU ch0 '2'
			COIL Rzone2_sel 0 1 0 0
		END
		SERIES
			EQU ch0 '3'
			COIL Rzone3_sel 0 1 0 0
		END
		SERIES
			EQU ch0 '4'
			COIL Rzone4_sel 0 1 0 0
		END
		SERIES
			EQU ch0 '5'
			COIL Rzone5_sel 0 1 0 0
		END
		SERIES
			EQU ch0 '6'
			COIL Rzone6_sel 0 1 0 0
		END
		SERIES
			EQU ch0 '7'
			COIL Rzone7_sel 0 1 0 0
		END
		SERIES
			EQU ch0 '8'
			COIL Rzone8_sel 0 1 0 0
		END
	END
END
RUNG
	CONTACTS Rzone1_sel 0 0 0
	CONTACTS YA_PWR 0 0 0
	PARALLEL
		READ_ADC Ach1
		MOVE TX_BUFF Ach1
	END
END
RUNG
	CONTACTS Rzone2_sel 0 0 0
	CONTACTS YA_PWR 0 0 0
	PARALLEL
		READ_ADC Ach2
		MOVE TX_BUFF Ach2
	END
END
RUNG
	CONTACTS Rzone3_sel 0 0 0
	CONTACTS YA_PWR 0 0 0
	PARALLEL
		READ_ADC Ach3
		MOVE TX_BUFF Ach3
	END
END
RUNG
	CONTACTS Rzone4_sel 0 0 0
	CONTACTS YA_PWR 0 0 0
	PARALLEL
		READ_ADC Ach4
		MOVE TX_BUFF Ach4
	END
END
RUNG
	CONTACTS Rzone5_sel 0 0 0
	CONTACTS YA_PWR 0 0 0
	PARALLEL
		READ_ADC Ach5
		MOVE TX_BUFF Ach5
	END
END
RUNG
	CONTACTS Rzone6_sel 0 0 0
	CONTACTS YA_PWR 0 0 0
	PARALLEL
		READ_ADC Ach6
		MOVE TX_BUFF Ach6
	END
END
RUNG
	CONTACTS Rzone7_sel 0 0 0
	CONTACTS YA_PWR 0 0 0
	PARALLEL
		READ_ADC Ach7
		MOVE TX_BUFF Ach7
	END
END
RUNG
	CONTACTS Rzone8_sel 0 0 0
	CONTACTS YA_PWR 0 0 0
	PARALLEL
		READ_ADC Ach8
		MOVE TX_BUFF Ach8
	END
END
RUNG
	PARALLEL
		CONTACTS Rzone1_sel 0 0 0
		CONTACTS Rzone2_sel 0 0 0
		CONTACTS Rzone3_sel 0 0 0
		CONTACTS Rzone4_sel 0 0 0
		CONTACTS Rzone5_sel 0 0 0
		CONTACTS Rzone6_sel 0 0 0
		CONTACTS Rzone7_sel 0 0 0
		CONTACTS Rzone8_sel 0 0 0
	END
	TON Ttransmit_delay 500000
		COIL Rdone 0 0 0 0
END
RUNG
	CONTACTS Rdone 0 0 0
	PARALLEL
		COIL Rzone1_sel 0 0 1 0
		COIL Rzone2_sel 0 0 1 0
		COIL Rzone3_sel 0 0 1 0
		COIL Rzone4_sel 0 0 1 0
		COIL Rzone5_sel 0 0 1 0
		COIL Rzone6_sel 0 0 1 0
		COIL Rzone7_sel 0 0 1 0
		COIL Rzone8_sel 0 0 1 0
	END
END
RUNG
	CONTACTS Rdone 0 0 0
	PARALLEL
		SERIES
						COIL Yzone1_led 0 1 0 0
		END
		SERIES
						COIL Yzone2_led 0 1 0 0
		END
		SERIES
						COIL Yzone3_led 0 1 0 0
		END
		SERIES
						COIL Yzone4_led 0 1 0 0
		END
		SERIES
						COIL Yzone5_led 0 1 0 0
		END
		SERIES
						COIL Yzone6_led 0 1 0 0
		END
		SERIES
						COIL Yzone7_led 0 1 0 0
		END
		SERIES
						COIL Yzone8_led 0 1 0 0
		END
	END
END
RUNG
	CONTACTS Rdone 0 0 0
	PARALLEL
		SERIES
						COIL Yzone1_led 0 0 1 0
		END
		SERIES
						COIL Yzone2_led 0 0 1 0
		END
		SERIES
						COIL Yzone3_led 0 0 1 0
		END
		SERIES
						COIL Yzone4_led 0 0 1 0
		END
		SERIES
						COIL Yzone5_led 0 0 1 0
		END
		SERIES
						COIL Yzone6_led 0 0 1 0
		END
		SERIES
						COIL Yzone7_led 0 0 1 0
		END
		SERIES
						COIL Yzone8_led 0 0 1 0
		END
	END
END
